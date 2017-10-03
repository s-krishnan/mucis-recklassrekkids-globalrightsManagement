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

            DateTime result;

            if (!DateTime.TryParse(val, out result))
            {
                throw new ArgumentException("Given dateTime argument is not in the correct format. Kindly check your input!!!");
            }

            return result;
        }

        public static String ConvertToString(DateTime dt)
        {
            return dt.ToString("dd'st' MMM yyyy");
        }
    }
}