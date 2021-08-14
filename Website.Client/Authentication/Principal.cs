using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Website.Client.Authentication
{
    record Principal(User ClientPrincipal);

    class User
    {
        [JsonPropertyName("identityProvider")]
        public string IdentityProvider { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("userDetails")]
        public string UserDetails { get; set; }

        [JsonPropertyName("userRoles")]
        public List<string> UserRoles { get; set; } = new();
    }
}