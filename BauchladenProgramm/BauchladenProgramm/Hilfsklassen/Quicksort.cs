using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public abstract class Quicksort<C>
    {
        // start with choosing a pivot element
        // Elements to the left of Pivot - left part list (<Pivot) | elements to the right of Pivot - right part list (> Pivot)
        // go through recursively

        public static List<C> sortQuick(List<C> unsorted, Func<C, C, int> comp)
        {
            // sort the array recursively -> index 0 and index to the last of array
            return sortQ(unsorted, comp, 0, unsorted.Count - 1);
        }

        private static List<C> sortQ(List<C> list, Func<C, C, int> comp, Int32 left, Int32 right)
        {
            int l = left; //l is the new leftbound
            int r = right;// r is the new rightbound
            C pivot = list[(left + right) / 2]; // Select the pivot in the middle of the list

            while (l <= r) // if any index on the left is the unordered list is smaller than the right index
            {
                while (comp(list[l], pivot) < 0)
                {
                    l++; //index increment until you find element that is not less than Pivot
                }

                while (comp(list[r], pivot) > 0)
                {
                    r--; //index decrement until you find element that is not less than Pivot
                }

                if (l <= r)
                {
                    C tmp = list[l];
                    list[l] = list[r];
                    list[r] = tmp;

                    l++;
                    r--;
                }
            }

            if (left < r)
            {
                sortQ(list, comp, left, r); // sort left part list
            }

            if (l < right)
            {
                sortQ(list, comp, l, right); // sort right part list
            }
            return list;
        }
    }
}
