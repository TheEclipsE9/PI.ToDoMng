using Microsoft.AspNetCore.Authentication;

namespace PI.ToDoMng.WebApi.Authentication
{
    public class OpaqueTokenAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string Scheme = "Opaque";

        public string CustomOption { get; set; }
    }
}
