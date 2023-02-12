using static System.Console;

const int THREADS_NUMBER = 4; // число потоков
const int N = 1000_000; // размер массива
object locker = new object();

Random rand = new Random();
int[] resSerial = new int[N].Select(r => rand.Next(0,5)).ToArray(); // не лямбда - линкью: библиотека для работы с перечисляемыми элементами 
int[] resParallel = new int[N];

Array.Copy(resSerial, resParallel, N); // не создает ссылок, а копирует элементы 

CountingSortExtended(resSerial);
PrepareParallelCountingSort(resParallel);
WriteLine(EqualityMatrix(resSerial, resParallel));


void PrepareParallelCountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();
    
    int offset = -min;
    int[] counters = new int[max + offset + 1];

    int eachThreadCalc = N / THREADS_NUMBER;
    var threadsParallel = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsParallel.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos)));
        threadsParallel[i].Start();
    }
    
    foreach (var thread in threadsParallel)
        thread.Join();
    
    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}


void CountingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (locker) // пока thread 1 выполняет код в скобках, он ставит замок 
        {              // на объект locker, так что другие threads будут ждать очереди
        counters[inputArray[i] + offset]++;
        }
    }
}



void CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;

    int[] counters = new int[max + offset + 1];


    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}



bool EqualityMatrix(int[] fmatrix, int[] smatrix)
{
    bool res = true;
    for (int i = 0; i < N; i++)
        res = res && (fmatrix[i] == smatrix[i]);
    return res;
}