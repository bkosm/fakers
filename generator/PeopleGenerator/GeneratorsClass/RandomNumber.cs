using System;

using System.Security.Cryptography;

namespace GeneratorsClass
{
    public static class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int Draw(int minValue, int maxValue)
        {
            byte[] randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d)- 0.00000000001d);
            int range = maxValue - minValue + 1;

            double randomValueRange = Math.Floor(multiplier * range);
            return (int)(minValue + randomValueRange);
        }
        public static int Draw()
        {
            byte[] randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            int range = (int.MaxValue/2)-1 - 0 + 1;

            double randomValueRange = Math.Floor(multiplier * range);
            return (int)(0 + randomValueRange);
        }

    }
}
