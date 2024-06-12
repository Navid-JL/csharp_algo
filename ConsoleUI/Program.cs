using Algorithms;

Random random = new();

List<int> mySeq = Enumerable.Range(0, 20).Select(r => random.Next(0, 100)).ToList();

foreach (var item in mySeq)
{
    Console.Write($"{item} ");
}

// var Result = Sorting.QuickSort(mySeq);
Sorting.BubbleSort(mySeq);
Console.WriteLine();

foreach (var item in mySeq)
{
    Console.Write($"{item} ");
}

Console.WriteLine();
