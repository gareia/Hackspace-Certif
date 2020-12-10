using System;

namespace ToDoAPI.Crosscuting.Extensions
{
    public static class DateTimeExtension
    {
        public static string DtToString(this DateTime dt)
        {
            int DD = dt.Day;
            int MO = dt.Month;
            int AAAA = dt.Year;

            if ((DD == 1) & (MO == 1) && (AAAA == 1))
                return "null";

            return $"{DD}/{MO}/{AAAA}-{dt.Hour}:{dt.Minute}";

        }
    }
}
