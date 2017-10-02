using System;


namespace RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities
{
    public static class DateTimeUtil
    {
        public static DateTime ConvertFromString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("DateTime can not be null.");
            }

            var val = text.Replace("st", "").Replace("th", ""); 
            return DateTime.Parse(val);
        }
    }
}

