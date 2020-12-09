using System;

namespace ToDoAPI.Crosscuting.Extensions
{
    public static class DateTimeExtension
    {
        public static string DtToString(this DateTime dt)
        {
            return $"{dt.Day}/{dt.Month}/{dt.Year}-{dt.Hour}:{dt.Minute}";

        }
    }
}
