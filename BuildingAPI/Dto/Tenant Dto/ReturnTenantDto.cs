namespace BuildingAPI.Dto.Tentant_Dto
{
    public class ReturnTenantDto
    {
        public int Id { get; set; }
        public string PersonalCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Action { get; set; }
        public int ApartmentId { get; set; }
    }
}
