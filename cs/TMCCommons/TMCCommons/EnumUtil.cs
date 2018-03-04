using System;
using System.Collections.Generic;
using System.Linq;

namespace TMCCommons
{
    public static class EnumUtil
    {
        /// <summary>
        /// Gets the values of an enum
        /// </summary>
        /// <returns>The values as a list</returns>
        /// <typeparam name="T">The enum type</typeparam>
        public static List<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
        }
    }
}
