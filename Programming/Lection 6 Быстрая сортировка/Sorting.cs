
public static class Sorting
{
  public static int[] SortQuick(this int[] collection, int left, int right)
  {
    int i = left; // указатели
    int j = right;

    int pivot = collection[Random.Shared.Next(left, right)];// выбираем опорный элемент случайным образом (как один из вариантов) от левого и правого края
    while (i <= j) // указываем, что пока левый указатель левее правого, а правый правее левого
    {
      while (collection[i] < pivot) i++; // увеличиваем позицию левого указателя, пока текущий элемент не будет меньше опорного
      while (collection[j] > pivot) j--; // или пока правый указатель не будет больше опорного

      if (i <= j) // если указатели не равны (т.е. не стоят на одном элементе) и левый стоит левее правого указателя, а правый правее левого,
      {
        int t = collection[i]; // тогда меняем местами элементы
        collection[i] = collection[j];
        collection[j] = t;
        i++;                 // и сдвигаем указатели
        j--;
      }
    }
    if (i < right) SortQuick(collection, i, right); // если указатели находятся в рамках массива, рекурсивно запускаем сортировку для левого края
    if (left < j) SortQuick(collection, left, j); // и для правого края
    return collection;
  }
}