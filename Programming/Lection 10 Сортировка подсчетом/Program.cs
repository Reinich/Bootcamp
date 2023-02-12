using static System.Console;
using static Infrastructure;

Clear();
Write("Введите количество элементов массива: ");
int size = Convert.ToInt32(ReadLine());

int[] array = CreateArray(size);
array.Show();

int max = array[0];                     // по умолчанию ставим первый элемент максимальным, для дальнейшего поиска
for (int i = 0; i < array.Length; i++)
    if (array[i] > max) max = array[i]; // находим максимальный элемент


int[] countArray = new int[max + 1];   // создаем новый массив размер с максимальное число: максимальное число самый последний индекс в массиве
for (int i = 0; i < array.Length; i++) 
    countArray[array[i]]++;           // подсчитываем сколько чисел-индексов: если в массиве три 1, то в новом массиве на месте array[1] будет стоять тройка

int index = 0;
for (int i = 0; i < countArray.Length; i++)  // главный опроверженец того, что цикл в цикле не всегда О(n^2), в данном случае O(n)
{
    for (int j = 0; j < countArray[i]; j++)  // повторяем столько раз, какая цифра стоит в данном месте, поскольку цифра означает количество этих элементов в основном массиве
        array[index++] = i;                 // подставляем индекс=цифру=элемент в основной массив и делаем индекс (искусственный) +1
}

array.Show();

