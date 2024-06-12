using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Algorithms;

public static class Sorting
{
    static void Merge(List<int> leftSequence, List<int> rightSequence, List<int> sequence)
    {
        int i = 0,
            j = 0,
            k = 0;

        while (i < leftSequence.Count && j < rightSequence.Count)
        {
            if (leftSequence[i] < rightSequence[j])
            {
                sequence[k] = leftSequence[i];
                i++;
            }
            else
            {
                sequence[k] = rightSequence[j];
                j++;
            }
            k++;
        }

        while (i < leftSequence.Count)
        {
            sequence[k] = leftSequence[i];
            i++;
            k++;
        }

        while (j < rightSequence.Count)
        {
            sequence[k] = rightSequence[j];
            j++;
            k++;
        }
    }

    public static void MergeSort(List<int> sequence)
    {
        if (sequence.Count > 1)
        {
            int middle = sequence.Count / 2;
            List<int> left = sequence[0..middle];
            List<int> right = sequence[middle..sequence.Count];

            MergeSort(left);
            MergeSort(right);

            Merge(left, right, sequence);
        }
    }

    public static List<int> QuickSort(List<int> sequence)
    {
        if (sequence.Count <= 1)
        {
            return sequence;
        }
        else
        {
            int pivot = sequence[0];
            List<int> left = [];
            List<int> right = [];

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] >= pivot)
                {
                    right.Add(sequence[i]);
                }
                else
                {
                    left.Add(sequence[i]);
                }
            }

            List<int> result = [];

            result.AddRange(QuickSort(left));
            result.Add(pivot);
            result.AddRange(QuickSort(right));

            return result;
        }
    }

    public static List<int> CountingSort(List<int> sequence)
    {
        int highest = sequence.Max() + 1;
        int[] helperArray = new int[highest];
        List<int> sortedList = [];

        foreach (int item in sequence)
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

    public static void InsertionSort(List<int> sequence)
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            int j = i;

            while (j > 0 && sequence[j - 1] > sequence[j])
            {
                (sequence[j - 1], sequence[j]) = (sequence[j], sequence[j - 1]);
                j--;
            }
        }
    }

    public static void SelectionSort(List<int> sequence)
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < sequence.Count; j++)
            {
                if (sequence[j] < sequence[minIndex])
                {
                    minIndex = j;
                }
            }

            int minValue = sequence[minIndex];
            sequence.RemoveAt(minIndex);
            sequence.Insert(i, minValue);
        }
    }

    public static void BubbleSort(List<int> sequence)
    {
        for (int i = 0; i < sequence.Count - 1; i++)
        {
            for (int j = 0; j < sequence.Count - i - 1; j++)
            {
                if (sequence[j] > sequence[j + 1])
                {
                    (sequence[j], sequence[j + 1]) = (sequence[j + 1], sequence[j]);
                }
            }
        }
    }
}
