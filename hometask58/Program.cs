void printColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(data);
    Console.ResetColor();
}

void showArray<T>(T[,] inputArray)
{
    printColorData($" \t");
    for (int i = 0; i < inputArray.GetLength(1); i++)
    {
        printColorData($"{i}\t");
    }
    Console.WriteLine();
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        printColorData($"{i}\t");
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Console.Write($"{inputArray[i,j]} \t");
        }
        Console.WriteLine();
    }
}

int[,] MultiplicationOfTwoMatrix(int[,] firstArray, int[,] secondArray)
{
    int [,] resultMatrix = new int[firstArray.GetLength(0), secondArray.GetLength(1)];
    for (int i = 0; i < firstArray.GetLength(0); i++)
    {
        for (int j = 0; j < secondArray.GetLength(1); j++)
        {
            for (int k = 0; k < secondArray.GetLength(0); k++)
            {
               resultMatrix[i,j] = resultMatrix[i,j] + firstArray[i,k] * secondArray[k,j];
            }
        }      
    }
    return resultMatrix;
}

int [,] firstUserArray =    {
                                {2, 4, 7},
                                {3, 2, 4},
                                {8, 5, 1}
                            };
showArray(firstUserArray);
Console.WriteLine();
int[,] secondUserArray =    {
                                {3, 4},
                                {3, 3},
                                {2, 6}
                            };
showArray(secondUserArray);
Console.WriteLine();
if (firstUserArray.GetLength(1) == secondUserArray.GetLength(0))
{
    Console.WriteLine("результирующая матрица будет:");
    int[,] resultMatrix = MultiplicationOfTwoMatrix(firstUserArray, secondUserArray);
    showArray(resultMatrix);
}
else
{
    Console.WriteLine("Результурущей матрицы для двух вышеприведенных матриц не существует");
    Console.WriteLine("Задайте такие 2 матрицы, количество столбцов первой их кторых будет равняться количеству строк во второй матрице");
}
Console.WriteLine();