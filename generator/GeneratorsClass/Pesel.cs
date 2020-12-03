using System;
using ExternalAPI;

namespace GeneratorsClass
{
    public static class Pesel
    {
        public static char[] getPesel(DateTime birthDate, char sex)
        {
            int[] Pesel = new int[11];

            Pesel[0] = birthDate.Year % 100 / 10;
            Pesel[1] = birthDate.Year % 10;

            if (birthDate.Year / 1000 == 1)
            {
                if ((birthDate.Year % 1000) / 100 == 8)
                {
                    Pesel[2] = (birthDate.Month + 80) / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
                else
                {
                    Pesel[2] = birthDate.Month / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
            }
            else
            {
                if ((birthDate.Year % 1000) / 100 == 0)
                {
                    Pesel[2] = (birthDate.Month + 20) / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
                else
                {
                    Pesel[2] = (birthDate.Month + 40) / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
            }

            Pesel[4] = birthDate.Day / 10;
            Pesel[5] = birthDate.Day % 10;

            Pesel[6] = RandomNumber.Draw(0, 9);
            Pesel[7] = RandomNumber.Draw(0, 9);
            Pesel[8] = RandomNumber.Draw(0, 9);

            if (sex == 'm')
                Pesel[9] = RandomNumber.Draw(0, 4) * 2 + 1;
            else
                Pesel[9] = RandomNumber.Draw(0, 4) * 2;

            Pesel[10] = (10 - (Pesel[0] + 3 * Pesel[1] + 7 * Pesel[2] + 9 * Pesel[3] + Pesel[4] + 3 * Pesel[5] + 7 * Pesel[6] + 9 * Pesel[7] + Pesel[8] + 3 * Pesel[9]) % 10) % 10;

            string s = string.Join("", Pesel);
            return s.ToCharArray();
        }

        public static char[] getPesel()
        {
            int[] Pesel = new int[11];
            DateTime birthDate = BirthDate.getBirthDate();
            char sex = Sex.getSex();

            Pesel[0] = birthDate.Year % 100 / 10;
            Pesel[1] = birthDate.Year % 10;

            if (birthDate.Year / 1000 == 1)
            {
                if ((birthDate.Year % 1000) / 100 == 8)
                {
                    Pesel[2] = (birthDate.Month + 80) / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
                else
                {
                    Pesel[2] = birthDate.Month / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
            }
            else
            {
                if ((birthDate.Year % 1000) / 100 == 0)
                {
                    Pesel[2] = (birthDate.Month + 20) / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
                else
                {
                    Pesel[2] = (birthDate.Month + 40) / 10;
                    Pesel[3] = birthDate.Month % 10;
                }
            }

            Pesel[4] = birthDate.Day / 10;
            Pesel[5] = birthDate.Day % 10;

            Pesel[6] = RandomNumber.Draw(0, 9);
            Pesel[7] = RandomNumber.Draw(0, 9);
            Pesel[8] = RandomNumber.Draw(0, 9);

            if (sex == 'm')
                Pesel[9] = RandomNumber.Draw(0, 4) * 2 + 1;
            else
                Pesel[9] = RandomNumber.Draw(0, 4) * 2;

            Pesel[10] = (10 - (Pesel[0] + 3 * Pesel[1] + 7 * Pesel[2] + 9 * Pesel[3] + Pesel[4] + 3 * Pesel[5] + 7 * Pesel[6] + 9 * Pesel[7] + Pesel[8] + 3 * Pesel[9]) % 10) % 10;

            string s = string.Join("", Pesel);
            return s.ToCharArray();
        }
    }
}
