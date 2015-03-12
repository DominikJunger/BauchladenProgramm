using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public abstract class SearchBinary<C>
    {
        public static C search(List<C> sorted, Func<C, C, int> comp, C key)
        {
            // Halve list is Pivot
            // If key <Pivot -> left part list -> halve again
            // If key> Pivot -> right part list -> halve again
            return SearchRecursive(sorted, key, comp, 0, sorted.Count - 1);
        }

        private static C SearchRecursive(List<C> list, C key, Func<C, C, int> comp, Int32 left, Int32 right)
        {
            C result = default(C);
            Int32 middle;
            bool isfound = false;

            if (list.Count > 0)
            {
                while (left <= right && !isfound)
                {
                    middle = (left + right) / 2;
                    if (comp(list[middle], key) == 0)
                    {
                        result = list[middle]; //the element we search is located
                        isfound = true;
                    }
                    else if (comp(list[middle], key) < 0)//the element we search is located to the right from the mid point
                    {
                        left = middle + 1;
                        result = SearchRecursive(list, key, comp, left, right);
                        isfound = true;
                    }
                    else if (comp(list[middle], key) > 0)//the element we search is located to the left from the mid point
                    {
                        right = middle - 1;
                        result = SearchRecursive(list, key, comp, 0, right);
                        isfound = true;
                    }
                }
            }
            // Element does not exist return default if C
            return result;
        }
    }
}

