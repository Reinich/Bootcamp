using static System.Console;
public static class Infrastructure
{
    public static int[] CreateArray(int n)
    {
        int[] array = Enumerable.Range(1, n)
                        .Select(item => Random.Shared.Next(0, 10))
                        .ToArray();
        
        return array;
    }

    public static int[] Show(this int[] array, string separator = ",")
    {
        string output = String.Join(separator, array);
        WriteLine($"{output}");
        return array;
    }
}