using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalTestPortal
{
    public static class Extensions
    {
        /// <summary>
        /// For a given string which could be split on comma convert to a list
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<string> ToSplitList(this string s)
        {
            return !string.IsNullOrWhiteSpace(s) ? s.Split(',').ToList() : null;
        }

        /// <summary>
        /// Convert list of strings to single joined string on comma
        /// </summary>
        public static string ToJoinedString(this List<string> s)
        {
            return s == null ? null : string.Join(",", s.ToArray());
        }
    }
}
