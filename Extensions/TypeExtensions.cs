using System;
using System.Collections;
using System.Collections.Generic;

namespace Extensions
{
    public static class TypeExtensions
    {
        public static IList CreateListOfType(this Type type)
        {
            var genericList = typeof(List<>).MakeGenericType(type);
            return Activator.CreateInstance(genericList) as IList;
        }
    }
}
