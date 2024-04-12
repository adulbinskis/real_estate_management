namespace BuildingAPI.Dto
{
    public class CreateApartmentDto
    {
       
        public int Number { get; set; } 

        public int Floor { get; set; } 

        public int NumberOfRooms { get; set; }

        public int NumberOfTenants { get; set; } 

        public int FullArea { get; set; }  

        public int LivingSpace { get; set; } 

        //public Guid BuildingId { get; set; }

        //public Building Building { get; set; }
        public int BuildingId { get; set; } 
    }
}
