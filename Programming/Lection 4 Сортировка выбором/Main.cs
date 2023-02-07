// СОРТИРОВКА ВЫБОРОМ

using static Sorting; // создаем файл cs, где описываем метод и используем его
using static System.Console; // теперь можно не писать Console перед Read, Write, Clear
using static Infrastructure;
// любой метод является классом, метод не может болтаться просто так



10.CreateArray(min: 10, max: 20) // MIN, MAX, (писать min-max необязательно)
    .Show("|")
    .SortSelection()
    .Show(" - ");



// int[] array = CreateArray(10, 100, 200); 
// Show(array);
// SortSelection(array);
// Show(array);

// старый вариант, без this и separator

