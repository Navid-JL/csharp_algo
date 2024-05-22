using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms;

public static class Sorting
{
    static void Merge(List<int> leftSeq, List<int> rightSeq, List<int> Seq)
    {
        int i = 0,
            j = 0,
            k = 0;
        while (i < leftSeq.Count && j < rightSeq.Count)
        {
            if (leftSeq[i] < rightSeq[j])
            {
                Seq[k] = leftSeq[i];
                i++;
            }
            else
            {
                Seq[k] = rightSeq[j];
                j++;
            }
            k++;
        }

        while (i < leftSeq.Count)
        {
            Seq[k] = leftSeq[i];
            i++;
            k++;
        }

        while (j < rightSeq.Count)
        {
            Seq[k] = rightSeq[j];
            j++;
            k++;
        }
    }

    public static void MergeSort(List<int> Seq)
    {
        if (Seq.Count > 1)
        {
            int mid = Seq.Count / 2;

            List<int> Left = Seq[0..mid];
            List<int> Right = Seq[mid..Seq.Count];

            MergeSort(Left);
            MergeSort(Right);

            Merge(Left, Right, Seq);
        }
    }

    public static List<int> QuickSort(List<int> Seq)
    {
        if (Seq.Count <= 1)
        {
            return Seq;
        }
        else
        {
            int pivot = Seq[0];
            List<int> left = [];
            List<int> right = [];
            for (int i = 1; i < Seq.Count; i++)
            {
                if (Seq[i] >= pivot)
                {
                    right.Add(Seq[i]);
                }
                else
                {
                    left.Add(Seq[i]);
                }
            }

            List<int> result = [];
            result.AddRange(QuickSort(left));
            result.Add(pivot);
            result.AddRange(QuickSort(right));

            return result;
        }
    }

    public static void InsertionSort(List<int> Seq)
    {
        for (int i = 0; i < Seq.Count; i++)
        {
            int j = i;

            while (j > 0 && Seq[j - 1] > Seq[j])
            {
                (Seq[j - 1], Seq[j]) = (Seq[j], Seq[j - 1]);
                j--;
            }
        }
    }

    public static void SelectionSort(List<int> Seq)
    {
        for (int i = 0; i < Seq.Count; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < Seq.Count; j++)
            {
                if (Seq[j] < Seq[minIndex])
                {
                    minIndex = j;
                }
            }

            int minValue = Seq[minIndex];
            Seq.RemoveAt(minIndex);
            Seq.Insert(i, minValue);
        }
    }

    public static List<int> CountingSort(List<int> Seq)
    {
        int highest = Seq.Max() + 1;
        int[] helperArray = new int[highest];
        List<int> sortedList = [];

        foreach (var item in Seq)
        {
            helperArray[item]++;
        }

        for (int i = 0; i < helperArray.Length; i++)
        {
            if (helperArray[i] > 0)
            {
                sortedList.AddRange(Enumerable.Repeat(i, helperArray[i]));
            }
        }

        return sortedList;
    }

    public static void BubbleSort(List<int> Seq)
    {
        for (int i = 0; i < Seq.Count - 1; i++)
        {
            for (int j = 0; j < Seq.Count - i - 1; j++)
            {
                if (Seq[j] > Seq[j + 1])
                {
                    (Seq[j], Seq[j + 1]) = (Seq[j + 1], Seq[j]);
                }
            }
        }
    }
}
