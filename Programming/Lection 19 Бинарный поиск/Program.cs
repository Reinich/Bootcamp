// Бинарный поиск. Время О(log n)


using static System.Console;
Clear();
string BinarySearch(int[] array, int item)
{
    int low = 0;
    int high = array.Length - 1;

    while (low <= high)
    {
        int mid = (low + high)/2;
        int guess = array[mid];
        if (guess == item)
            return $"{mid}";
        if (guess > item)
        {
            high = mid - 1;
            WriteLine($"Много - {array[mid]}");
        }
        else
        {
            low = mid + 1;
            WriteLine($"Мало - {array[mid]}");
        }
    }
    return "Этого числа здесь не существует";
}

int[] array = Enumerable.Range(1, 10)
                .Select(item => Random.Shared.Next(1, 30))
                .ToArray();
WriteLine($"{String.Join(", ", array)}");
WriteLine("Введите число: ");
int n = Convert.ToInt32(ReadLine());
WriteLine(BinarySearch(array, n));