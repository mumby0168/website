using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace Website.Client.Authentication
{
    public class AzureStaticWebAppsAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _client;

        public AzureStaticWebAppsAuthenticationStateProvider(HttpClient client)
        {
            Console.WriteLine("Made auth call");
            _client = client;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            Principal principal;

            try
            {
                principal = await _client.GetFromJsonAsync<Principal>(".auth/me");
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }

            if (principal?.ClientPrincipal is not null)
            {

                identity = new ClaimsIdentity(principal.ClientPrincipal.IdentityProvider);
                
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, principal.ClientPrincipal.UserId));
                identity.AddClaim(new Claim(ClaimTypes.Name, principal.ClientPrincipal.UserDetails));
                identity.AddClaims(principal.ClientPrincipal.UserRoles.Select(role => new Claim(ClaimTypes.Role, role)));
                
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
    
    
}