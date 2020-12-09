using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ToDoAPI.Crosscuting.Extensions
{
    public static class StringExtension
    {
        public static DateTime ToDateTime(this string str)
        {
            string pattern = "[/:-]";
            string[] substrs = Regex.Split(str, pattern);

            int DD = int.Parse(substrs[0]);
            int MO = int.Parse(substrs[1]);
            int AAAA = int.Parse(substrs[2]);
            int HH = int.Parse(substrs[3]);
            int MI = int.Parse(substrs[4]);
            int SS = 0;

            return new DateTime(AAAA, MO, DD, HH, MI, SS);
        }
    }
}
