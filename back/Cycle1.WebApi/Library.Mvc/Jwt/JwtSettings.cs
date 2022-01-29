namespace A3.Library.Mvc.Jwt
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigningKey { get; set; } = true;

        public string IssuerSigningKey { get; set; } = String.Empty;

        public bool ValidateIssuer { get; set; } = true;

        public string ValidIssuer { get; set; } = String.Empty;

        public bool ValidateAudience { get; set; } = true;

        public string ValidAudience { get; set; } = String.Empty;

        public bool RequireExpirationTime { get; set; } = true;

        public bool ValidateLifetime { get; set; } = true;
    }
}
