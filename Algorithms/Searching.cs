using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms;

public static class Searching
{
    public static int BinarySearch(List<int> sequence, int key)
    {
        int low = 0,
            high = sequence.Count - 1;

        while (low <= high)
        {
            int middle = (high + low) / 2;

            if (key == sequence[middle])
            {
                return middle;
            }
            else if (key > sequence[middle])
            {
                low = middle + 1;
            }
            else
            {
                high = middle - 1;
            }
        }

        return -1;
    }
}
