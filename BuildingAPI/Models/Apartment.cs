namespace BuildingAPI.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public int Floor { get; set; }

        public int NumberOfRooms { get; set; }

        public int NumberOfTenants { get; set; }

        public int FullArea { get; set; }

        public int LivingSpace { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; } = null!;
        public List<Tenant> Tenants { get; set; } = null!;


    }
}
