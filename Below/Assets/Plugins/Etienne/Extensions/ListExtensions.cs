using System;
using System.Collections.Generic;
using System.Linq;

namespace Etienne {
    public static partial class Extensions {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static T Last<T>(this List<T> list) {
            return list[list.Count - 1];
        }

        public static string[] RemoveAt(this string[] array, int index) {
            return array.Where(o => o != array[index]).ToArray();
        }
    }
}