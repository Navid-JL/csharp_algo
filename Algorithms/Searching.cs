using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms;

public static class Searching
{
    public static int BinarySearch(List<int> Seq, int key)
    {
        int low = 0,
            high = Seq.Count - 1;

        while (low <= high)
        {
            int mid = (high + low) / 2;

            if (key == Seq[mid])
            {
                return mid;
            }
            else if (key > Seq[mid])
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1;
    }

    public static int LinearSearch(List<int> Seq, int key)
    {
        for (int i = 0; i < Seq.Count; i++)
        {
            if (key == Seq[i])
            {
                return i;
            }
        }
        return -1;
    }
}
