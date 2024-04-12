namespace BuildingAPI.Dto.TokenDto
{
    public class TokenDto
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public string? Role { get; set; }
        public int? UserId { get; set; }
    }
}
