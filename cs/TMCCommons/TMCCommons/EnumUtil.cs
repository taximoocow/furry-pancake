using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TMCCommons
{
    /// <summary>
    /// Helper utility for enums, to extend their usability.
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// Gets the values of an enum
        /// </summary>
        /// <returns>The values as a list</returns>
        /// <typeparam name="T">The enum type</typeparam>
        public static List<TEnum> GetValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList<TEnum>();
        }

        /// <summary>
        /// Gets the attributes class from the given enum. This helps extend an enum with attributes.
        /// </summary>
        /// <returns>The attributes of an enum</returns>
        /// <param name="eEnum">Enum for which we want the attributes</param>
        /// <typeparam name="TEnum">The enum to extend with attributes</typeparam>
        /// <typeparam name="TAttr">The attributes class added to an enum</typeparam>
        public static TAttr GetAttributes<TEnum, TAttr>(TEnum eEnum) where TAttr : Attribute
        {
            return (TAttr)Attribute.GetCustomAttribute(GetField(eEnum), typeof(TAttr));
        }

        private static FieldInfo GetField<TEnum>(TEnum eEnum)
        {
            return typeof(TEnum).GetField(Enum.GetName(typeof(TEnum), eEnum));
        }
    }
}
