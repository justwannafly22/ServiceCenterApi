using System;

namespace IdentityService.BusinessLogic
{
    public static class PasswordService
    {
        public static bool DoesPasswordMatch(string userSubmittedPassword, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(userSubmittedPassword, hashedPassword);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string HashPassword(string password)
        {
            try
            {
                var salt = BCrypt.Net.BCrypt.GenerateSalt();
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
                return hashedPassword;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
