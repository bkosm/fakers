/* url do poczytania: https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-5.0 */

namespace ExternalAPI
{
    public sealed class PersonFromAPI
    {
        #region IMPELEMEN_IDISPOSABLE

        #endregion

        #region VARIABLE_PERSONAL_DATA
        public string name { get; set; }
        public string address { get; set; }

        #region UNUSED
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string maiden_name { get; set; }
        public string birth_data { get; set; }
        public string phone_h { get; set; }
        public string phone_w { get; set; }
        public string email_u { get; set; }
        public string email_d { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string domain { get; set; }
        public string useragent { get; set; }
        public string ipv4 { get; set; }
        public string macaddress { get; set; }
        public string plasticcard { get; set; }
        public string cardexpir { get; set; }
        public int bonus { get; set; }
        public string company { get; set; }
        public string color { get; set; }
        public string uuid { get; set; }
        public int height { get; set; }
        public float weight { get; set; }
        public string blood { get; set; }
        public string eye { get; set; }
        public string hair { get; set; }
        public string pict { get; set; }
        public string url { get; set; }
        public string sport { get; set; }
        public string ipv4_url { get; set; }
        public string email_url { get; set; }
        public string domain_url { get; set; }
        #endregion

        #endregion

        ~PersonFromAPI(){}

    }
}
