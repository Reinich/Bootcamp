// СОРТИРОВКА ПУЗЫРЬКОМ

Console.Clear();
Console.Write("Введите количество элементов массива: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] array = new int[n];
for (int i = 0; i < n; i++)
{
    Console.Write(i + " элемент: ");
    array[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Начальный массив: [" + string.Join(", ", array) + "]");
Console.WriteLine();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n - 1 - i; j++)      // можно добавить "-i", чтобы не повторять сравнения 
    {                                       // последних эл-ов, поскольку они сразу стоят в конце массива
        if (array[j] > array[j + 1])
        {
            int temp = array[j];
            array[j] = array[j + 1];
            array[j + 1] = temp;
        }
    }
    Console.WriteLine(i + " [" + string.Join(", ", array) + "]");
}