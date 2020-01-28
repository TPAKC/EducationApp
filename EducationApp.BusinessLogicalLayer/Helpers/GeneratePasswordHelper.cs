using EducationApp.BusinessLogicalLayer.Helpers.Interfaces;
using System;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public class GeneratePasswordHelper : IGeneratePasswordHelper
    {
        private const int LengthPassword = 8;
        private const int LengthChars = 73;
        private const string Chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";

        public string GeneratePassword()
        {
            var random = new Random();
            string password = string.Empty;
            for (int i = 0; i < LengthPassword; i++)
            {
                password += Chars[random.Next(0, LengthChars - 1)];
            }
            return password;
        }
    }
}
