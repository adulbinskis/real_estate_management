﻿namespace BuildingAPI.Dto
{
    public class UpdateBuildingDto
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public int? UserId { get; set; }
    }
}
