using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using PI.ToDoMng.WebApi.Application.Helpers;
using PI.ToDoMng.WebApi.Domain;
using PI.ToDoMng.WebApi.Domain.Interfaces;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace PI.ToDoMng.WebApi.Authentication
{
    public class OpaqueTokenHandler : AuthenticationHandler<OpaqueTokenAuthenticationOptions>
    {
        private readonly ISessionStore _sessionStore;

        public OpaqueTokenHandler(IOptionsMonitor<OpaqueTokenAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISessionStore sessionStore) : base(options, logger, encoder)
        {
            _sessionStore = sessionStore;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryExtractBearerToken(out string token))
                return Task.FromResult(AuthenticateResult.Fail("Missing header."));

            if (!_sessionStore.TryGetValidSession(token, out var session))
                return Task.FromResult(AuthenticateResult.Fail("Invalid or expired token."));

            Request.HttpContext.Items[Constants.Auth.SESSION_ITEM_KEY] = session;

            var claims = new[]
            {
                new Claim("UserId", session.UserId.ToString()),
                new Claim("ExpiresAt", session.ExpiresAt.ToString("O")),
                new Claim("CustomOptionValue", Options.CustomOption)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
