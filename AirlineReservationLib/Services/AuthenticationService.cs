using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationLib
{
    public class AuthenticationService : IAuthenticationService
    {
        public User AuthenticateUser(string username, string clearTextPassword)
        {
            try
            {
                var userDataProvider = new UserDataProvider();
                var user = userDataProvider.GetUserByUsername(username);
                var calculatedHashedPassword = string.IsNullOrEmpty(clearTextPassword) ? null : CalculateHash(clearTextPassword, username);
                var isUsernamePasswordMatched = user != null && user.Username == username && user.HashedPassword == calculatedHashedPassword;
                if (!isUsernamePasswordMatched)
                {
                    return null;
                }
                return new User() { UserDao = user };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
