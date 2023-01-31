using System.Diagnostics;

Console.Clear();

int size = 10000;
int m = 3;
int[] array = Enumerable.Range(1, size)
                        .Select(item => Random.Shared.Next(10))
                        .ToArray();
// Console.WriteLine($"[{string.Join(", ", array)}]");

Stopwatch sw = new();
sw.Start();

int max = 0;
for (int i = 0; i < array.Length - m; i++)
{
    int t = 0;
    for (int j = i; j < i + m; j++)
    {
        t += array[j];
        if (t > max) max = t;
    }
}


sw.Stop();
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");
Console.WriteLine(max);