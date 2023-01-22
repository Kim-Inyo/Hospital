using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HospitalSystem.Token
{
    public class AuthOptions
    {
        public const string ISSUER = "HospitalSystem";
        public const string AUDIENCE = "Hospital";
        const string KEY = "secret_key";
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}