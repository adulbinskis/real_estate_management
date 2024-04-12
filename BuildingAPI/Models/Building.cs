namespace BuildingAPI.Models
{
    public class Building
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; } = null!;

        public List<Apartment>? Apartments { get; set; } = null!;

    }
}
