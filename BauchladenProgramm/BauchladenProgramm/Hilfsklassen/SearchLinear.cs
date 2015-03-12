using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public abstract class SearchLinear<C>
    {
        public static C search(List<C> unsorted, Func<C, C, bool> comp, C key)
        {
            C result = default(C);
            for (int i = 0; i < unsorted.Count; i++)
            {
                if (comp(unsorted[i], key))
                {
                    result = unsorted[i]; // index of the element to search from
                }
            }
            // Element does not exist return default if C
            return result;
        }
    }
}
