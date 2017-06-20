using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StartingPoint.API.Helpers
{
    public static class AuthenticationHelper
    {
        private static RNGCryptoServiceProvider randomNumberGenerator = new RNGCryptoServiceProvider();

        public static String GetToken()
        {
            int size = 15; // size of token generated
            String token = String.Empty;

            //now generate a token until the token you generate is unique
            token = GenerateToken(size);
            while (TokenExists(token))
            {
                token = GenerateToken(size);
            }

            return token;

        }

        //generate token
        private static String GenerateToken(int Size)
        {
            String characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] characterArray = characters.ToCharArray();
            StringBuilder result = new StringBuilder(Size);

            for (int i = 0; i < Size; i++)
            {
                result.Append(characterArray[Next(0, characterArray.Length)]);
            }

            return result.ToString();
        }

        //check the database to ensure our token is unique
        private static Boolean TokenExists(String Token)
        {
            //using (OverlordDashboardEntities context = new OverlordDashboardEntities())
            //{
            //    return context.AuthenticationTokens.Where(o => o.Token == Token).Any();
            //}

            return false;
        }

        private static Boolean IsValidNumber(int Number, int MinValue, int MaxValue)
        {
            if (Number >= MinValue && Number <= MaxValue)
                return true;

            return false;
        }

        private static int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (int)Math.Floor((minValue + ((double)maxValue - minValue) * NextDouble()));
        }

        private static double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            randomNumberGenerator.GetBytes(data);
            var randUint = BitConverter.ToUInt32(data, 0);
            return randUint / (uint.MaxValue + 1.0);
        }
    }
}