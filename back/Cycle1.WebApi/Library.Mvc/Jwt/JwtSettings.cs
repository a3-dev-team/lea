namespace A3.Library.Mvc.Jwt
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;

        public string ValidIssuer { get; set; } = string.Empty;

        public string ValidAudience { get; set; } = string.Empty;
    }
}
