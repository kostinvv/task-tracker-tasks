namespace WebApi
{
    public class AuthenticationOptions
    {
        public const string Section = "Authentication";

        public SchemesOptions Schemes { get; set; } = new();

        public KeycloakOptions Keycloak { get; set; } = new();
    }

    public class SchemesOptions
    {
        public BearerOptions Bearer { get; set; } = new();
    }

    public class BearerOptions
    {
        public string Authority { get; set; } = string.Empty;

        public List<string> Audience { get; set; } = [];
    }

    public class KeycloakOptions
    {
        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;

        public List<string> Scope { get; set; } = [];
    }
}
