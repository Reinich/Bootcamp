//MIN -> MAX БЫСТРАЯ СОРТИРОВКА
// 0 1 2 3 4 5 6 7
// 7 6 3 4 5 1 2 3
// ^ выбираем главный элемент и сравниваем со всеми остальными
// на предмет поиска другого минимального, когда находим - меняем их местами
// и так с последующими элементами

using static Sorting;       // создаем файл cs, где описываем метод и используем его
using static System.Console; // теперь можно не писать Console перед Read, Write, Clear
using static Infrastructure;

Clear();
// int[] array = CreateArray(10);
// Show(array);
// SortSelection(array);
// Show(array);

// если добавить this к переденным данным, и возвратить массив:

10.CreateArray(min: 10, max: 20) // MIN, MAX, писать min-max необязательно 
    .Show()
    .SortSelection()
    .Show();


