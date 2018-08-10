using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace EVErything
{
    public class CustomJwtSecurityTokenHandler : ISecurityTokenValidator
    {
        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; }

        public bool CanReadToken(string securityToken)
        {
            return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            ClaimsPrincipal p = null;
            validatedToken = null;
            return p;
        }
    }
}