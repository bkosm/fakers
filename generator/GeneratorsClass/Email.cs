using System;
using System.Globalization;
using System.Text;
using ExternalAPI;

namespace GeneratorsClass
{
    public static class Email
    {
        static string[] _popularEmail = new string[] {"gmail.com", "yahoo.com", "outlook.com", "protonmail.com", "aolmail.com",
                                            "zaho.com","gmx.com","icloud.com","yandex.com","mail.com", "o2.pl", "wp.pl", "onet.pl",
                                            "interia.pl", "gazeta.pl" };

        #region ADDITIONAL_FUNCTIONS
        /// <summary>
        /// Usuwa znaki diakrytyczne: ł -> l
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string _removeDiacritics(string text)
        {
            Logger.emailDiacritics();
            var stringBuilder = new StringBuilder();
            try
            {
                text = text.ToLower();
                var normalizedString = text.Normalize(NormalizationForm.FormD);


                foreach (var c in normalizedString)
                {
                    if (c != 'ł')
                    {
                        var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                        if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                        {
                            stringBuilder.Append(c);
                        }
                    }
                    else
                        stringBuilder.Append('l');
                }

            }
            catch (Exception e)
            {
                Logger.log(e);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);


        }

        private static bool _draw()
        {
            if (RandomNumber.Draw(0, 1) == 1)
                return true;
            else
                return false;
        }

        private static string _drawN()
        {
            int start = (int)Math.Pow(10, RandomNumber.Draw(0, 7));
            int end = start * 10;
            return RandomNumber.Draw(start, end).ToString();

        }

        private static string _getDomen()
        {
            Logger.emailDomain();
            return _popularEmail[RandomNumber.Draw(0, _popularEmail.Length - 1)];
        }
        #endregion  

        #region MAIL_GENERATOR
        /// <summary>
        /// FALSE: imieNazwisko@domena || nazwiskoImie@domena TRUE: imieNazwiskoLiczba@domena || nazwiskoImieLiczba@domena
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        static string _classicEmail(string firstName, string lastName)
        {
            Logger.emailClassic();
            try
            {
                if (_draw())
                {
                    if (_draw())
                        return ($"{firstName}{lastName}{_drawN()}@{ _getDomen()}");
                    else
                        return ($"{lastName}{firstName}{_drawN()}@{ _getDomen()}");
                }
                else
                {
                    if (_draw())
                        return ($"{firstName}{lastName}@{_getDomen()}");
                    else
                        return ($"{lastName}{firstName}@{ _getDomen()}");
                }
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }
        }

        /// <summary>
        /// imieJakascyfra@adres.domena
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        static string _nameEmail(string firstName, string lastName)
        {
            Logger.emailName();
            try
            {
                if (_draw())
                    return $"{firstName}{_drawN()}@{ _getDomen()}";
                else
                    return $"{lastName}{_drawN()}@{ _getDomen()}";
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }

        }

        /// <summary>
        /// FALSE: adam - a_nazwisko@domena || kowalski - k_imie@domena TRUE: adam - a_nazwiskoLiczba@domena || kowalski - k_imieLiczba@domena
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static string _firstLetterEmail(string firstName, string lastName)
        {
            Logger.emailFirst();
            try
            {
                if (_draw())
                {
                    if (_draw())
                        return $"{(char)firstName[0]}_{lastName}{_drawN()}@{ _getDomen()}";
                    else
                        return $"{(char)lastName[0]}_{firstName}{_drawN()}@{ _getDomen()}";
                }
                else
                {
                    if (_draw())
                        return $"{(char)firstName[0]}_{lastName}@{ _getDomen()}";
                    else
                        return $"{(char)lastName[0]}_{firstName}@{ _getDomen()}";
                }
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }

        }

        static string _differentEmail(string firstName, string lastName)
        {
            string[] different = new string[] { "kontakt.pl", "contact.com", "info.com", "mojafirma.pl" };
            string[] domen = new string[] { ".pl", ".com" };
            string[] contact = new string[] { "kontakt", "contact", "info", "mojafirma" };

            try
            {
                if (_draw())
                {
                    if (_draw())
                    {
                        if (_draw())
                            return $"{firstName}@{different[RandomNumber.Draw(0, different.Length - 1)]}";
                        else
                            return $"{lastName}@{different[RandomNumber.Draw(0, different.Length - 1)]}";
                    }
                    else
                    {
                        if (_draw())
                            return $"{firstName}{lastName}@{different[RandomNumber.Draw(0, different.Length - 1)]}";
                        else
                            return $"{lastName}{firstName}@{different[RandomNumber.Draw(0, different.Length - 1)]}";
                    }
                }
                else
                {
                    if (_draw())
                    {
                        if (_draw())
                            return $"{firstName}@{lastName}{domen[RandomNumber.Draw(0, domen.Length - 1)]}";
                        else
                            return $"{lastName}@{firstName}{domen[RandomNumber.Draw(0, domen.Length - 1)]}";
                    }
                    else
                    {
                        if (_draw())
                            return $"{contact[RandomNumber.Draw(0, contact.Length - 1)]}@{firstName}{lastName}{domen[RandomNumber.Draw(0, domen.Length - 1)]}";
                        else
                            return $"{contact[RandomNumber.Draw(0, contact.Length - 1)]}@{lastName}{firstName}{domen[RandomNumber.Draw(0, domen.Length - 1)]}";
                    }
                }
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }
        }
        #endregion

        public static string getMail(string firstName, string lastName)
        {
            Logger.emailStart();

            try
            {
                var name = new string[] { _removeDiacritics(firstName), _removeDiacritics(lastName) };
                switch ((int)RandomNumber.Draw(1, 4))
                {
                    case 1:
                        return _classicEmail(name[0], name[1]);
                    case 2:
                        return _firstLetterEmail(name[0], name[1]);
                    case 3:
                        return _nameEmail(name[0], name[1]);
                    case 4:
                        return _differentEmail(name[0], name[1]);
                }
            }
            catch (Exception e)
            {
                Logger.log(e);
                
            }
            return null;
        }









    }
}
