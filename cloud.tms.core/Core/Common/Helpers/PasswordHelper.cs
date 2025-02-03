using System.Security.Cryptography;

namespace cloud.tms.core.Core.Common.Helpers
{
    public static class PasswordHelper
    {
        public static void CreatePassword(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }

        public static bool VerifyPassword(string password, string storedhash, string storedsalt)
        {
            using (var hmac = new HMACSHA512(Convert.FromBase64String(storedsalt)))
            {
                var computedHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
                return computedHash == storedhash;
            }
        }
    }
}
