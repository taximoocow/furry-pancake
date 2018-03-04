using System;
using System.Reflection;

namespace TMCCommons
{
    /// <summary>
    /// Helps extend an enum with attributes
    /// TEnum : The enum to extend with attributes
    /// TAttr : The attributes class added to an enum
    /// </summary>
    public static class EnumExtender<TEnum, TAttr> where TAttr : Attribute
    {
        /// <summary>
        /// Gets the attributes class from the given enum
        /// </summary>
        /// <returns>The attributes of an enum</returns>
        /// <param name="eEnum">Enum for which we want the attributes</param>
        public static TAttr GetAttributes(TEnum eEnum)
        {
            return (TAttr)Attribute.GetCustomAttribute(ForValue(eEnum), typeof(TAttr));
        }

        private static MemberInfo ForValue(TEnum eEnum)
        {
            return typeof(TEnum).GetField(Enum.GetName(typeof(TEnum), eEnum));
        }
    }
}
