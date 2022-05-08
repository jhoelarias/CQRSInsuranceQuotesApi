namespace Coterie.Domain.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    public static class EnumExtensions
    {
        public static TAttribute GetEnumAttribute<TAttribute>(this System.Enum enumVal) where TAttribute : Attribute
        {
            var memberInfo = enumVal.GetType().GetMember(enumVal.ToString());
            return memberInfo[0].GetCustomAttributes(typeof(TAttribute), false).OfType<TAttribute>().FirstOrDefault();
        }

        public static string GetDescription(this System.Enum enumValue) =>
            enumValue.GetEnumAttribute<DescriptionAttribute>()?.Description ?? enumValue.ToString();

        public static string GetEnumDescription<T>(this int value) where T : struct, IConvertible =>
            typeof(T).IsEnum && System.Enum.IsDefined(typeof(T), value)
                ? ((System.Enum)System.Enum.ToObject(typeof(T), value)).GetDescription()
                : string.Empty;
    }
}