using CsvHelper.TypeConversion;
using System;


namespace RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities
{
    public class TypeConverter : DefaultTypeConverter
    {
        public override bool CanConvertFrom(Type type)
        {
            return typeof(String) == type;
        }

        public override bool CanConvertTo(Type type)
        {
            return typeof(DateTime) == type;
        }

        public override object ConvertFromString(TypeConverterOptions options, string text)
        {
            return DateTimeUtil.ConvertFromString(text);
        }
    }
}

