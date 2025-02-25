﻿namespace BuildingAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string Role { get; set; } = string.Empty;
        public List<Building>? Building { get; set; } = null!;

    }
}
