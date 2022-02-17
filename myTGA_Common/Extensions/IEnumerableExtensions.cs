using System.Collections.Generic;
using System.Linq;

namespace myTGA_Common.Extensions {
    public static class IEnumerableExtensions {
        public static bool IsEmpty<T>(this IEnumerable<T> list) {
            if (list == null) {
                return true;
            } else {
                return list.Count() == 0;
            }
        }
    }
}
