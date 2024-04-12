namespace BuildingAPI.Dto
{
    public class CreateTenantDto
    {
        public string PersonalCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int ApartmentId { get; set; }
    }
}
