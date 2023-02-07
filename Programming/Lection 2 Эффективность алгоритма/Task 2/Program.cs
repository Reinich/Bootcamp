using System.Diagnostics;

//  - - - - - + + +
//i           v
//  0 1 2 3 4 5 6 7 8 9 
//  1 5 4 1 3 4 7 4 1 2
//j           ^ ^ ^

Console.Clear();

int size = 10;
int m = 3;
int[] array = Enumerable.Range(1, size)
                        .Select(item => Random.Shared.Next(10))
                        .ToArray();
Console.WriteLine($"[{string.Join(", ", array)}]");

Stopwatch sw = new();
sw.Start();

int max = 0;
for (int j = 0; j < m; j++) max += array[j];
int t = max;
for (int i = 1; i < array.Length - m + 1; i++)
{
    t = t - array[i - 1] + array[i + (m - 1)];
    if (t > max) max = t;
}

sw.Stop();
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");
Console.WriteLine(max);