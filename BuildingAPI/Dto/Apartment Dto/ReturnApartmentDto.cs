namespace BuildingAPI.Dto.Apartment_Dto
{
    public class ReturnApartmentDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }

        public int NumberOfRooms { get; set; }

        public int NumberOfTenants { get; set; }

        public int FullArea { get; set; }

        public int LivingSpace { get; set; }
        public string Action { get; set; }

        public int BuildingId { get; set; }

    }
}
