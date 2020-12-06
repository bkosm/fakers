using System;
using ExternalAPI;

namespace GeneratorsClass
{
    public static class DeathDate
    {
        public static DateTime getDeathDate(DateTime birthDate)
        {
            try
            {
                Logger.deathDateStart();
                return Date.getDeathDate(birthDate);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return getDeathDate(birthDate);
            }

        }
    }
}
