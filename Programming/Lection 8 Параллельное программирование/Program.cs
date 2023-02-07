// ПАРАЛЛЕЛЬНОЕ ПРОГРАММИРОВАНИЕ

using static System.Console;

const int N = 101; //
const int THREADS_NUMBER = 10; // можно 8

int[,] MatrixGeneration(int rows, int columns)
{
    Random rand = new Random();
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
            res[i, j] = rand.Next(-10, 10);
    }
    return res;
}

int[,] serialMulRes = new int[N, N];// результат выполнения умножения матриц в однопотоке
int[,] threadMulRes = new int[N, N];// результат параллельного умножения матриц

int[,] firstMatrix = MatrixGeneration(N, N);
int[,] secondMatrix = MatrixGeneration(N, N);

SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix);
WriteLine(EqualityMatrix(serialMulRes, threadMulRes));

void SerialMatrixMul(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы!");
    for (int i = 0; i < a.GetLength(0); i++) // throw - бросить, exception - исключение, фраза останавливает ВСЮ программу, а break - только цикл
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
                serialMulRes[i, j] += a[i, k] * b[k, j];
        }
    }
}

void PrepareParallelMatrixMul(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы!");
    int eachThreadCalc = N / THREADS_NUMBER;
    var threadList = new List<Thread>(); // thread - программа знает, что это такое - потоки
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        // если последний поток
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadList.Add(new Thread(() => ParallelMatrixMul(a, b, startPos, endPos)));
        threadList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
        threadList[i].Join(); // соединяем поток к главному потоку
}

void ParallelMatrixMul(int[,] a, int[,] b, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++) 
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
                threadMulRes[i, j] += a[i, k] * b[k, j];
        }
    }
}

bool EqualityMatrix(int[,] fmatrix, int[,] smatrix)
{
    bool res = true;
    for (int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fmatrix.GetLength(1); j++)
            res = res && (fmatrix[i, j] == smatrix[i, j]);
    }
    return res;
}





