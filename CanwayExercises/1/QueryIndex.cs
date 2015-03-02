using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises
{
    public class QueryIndex
    {
        private int[] array;

        public int[] Array
        {
            get { return array; }
        }

        public QueryIndex(int[] array)
        {
            if(array == null || array.Length ==0)
            {
                throw new ArgumentNullException("array");
            }

            this.array = array;
        }

        public int SearchIndex(int value)
        {
            return BinarySearch(Array, value);
        }

        private static int BinarySearch(int[] array, int value)
        {
            int index = -1;

            int low = 0;
            int high = array.Length - 1;
            int middle = -1;

            while (low <= high)
            {
                middle = (low + high) / 2;

                int tmpIndex = IndexMapping(middle, array.Length);
                int tmpValue = array[tmpIndex];
                //if (value == array[middle])
                if (value == tmpValue)
                {
                    index = tmpIndex;
                    break;
                }
                if (value < tmpValue)
                    low = middle + 1;
                else
                    high = middle - 1;
            }
            return index;
        }

        private static int IndexMapping(int i, int n)
        {
            if (n % 2 == 1)
            {
                if (i <= (n / 2))
                {
                    return 2 * i;
                }
                return (n / 2) * 2 - 1 - (i - (n + 1) / 2) * 2;
            }
            else
            {
                if (i <= (n / 2) - 1)
                {
                    return 2 * i;
                }
                return 2 * (n - i) - 1;
            }
        }
    }
}
