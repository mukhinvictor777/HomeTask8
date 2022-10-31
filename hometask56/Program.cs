int[,] GenerateArray(int height, int weight, int deviation)
{
    int[,] generatedArray = new int[height, weight];
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < weight; j++)
        {
            generatedArray[i,j] = new Random().Next(-deviation, deviation+1);
        }
    }
    return generatedArray;
}

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

int FindStringWithSmallestSum (int [,] incomigArray)
{
    int sumOfString = 0;
    int minSumOfString = 0;
    int indexOfMinString = 0;
    for (int i = 0; i < incomigArray.GetLongLength(1); i++)
    {
        minSumOfString = minSumOfString + incomigArray[0,i]; // записываем сумму первой строки в минимальную сумму.
    }
    for (int i = 1; i < incomigArray.GetLongLength(0); i++)
    {
        for (int j = 0; j < incomigArray.GetLongLength(1); j++)
        {
            sumOfString = sumOfString + incomigArray[i,j];
        }
        if (sumOfString < minSumOfString)
        {
            minSumOfString = sumOfString;
            indexOfMinString = i;
        }
        sumOfString = 0;
    }
    return indexOfMinString;
}

int [,] generatedArray = GenerateArray(10,5,10);
showArray(generatedArray);
int result = FindStringWithSmallestSum(generatedArray);
Console.WriteLine($"Номер строки с минимальной суммой элементов: {result} строка");
Console.WriteLine();
int[,] userArray =  {
                        {1, 4, 7, 2},
                        {5, 9, 2, 3},
                        {8, 4, 2, 4},
                        {5, 2, 6, 7}
                    };
showArray(userArray);
int resultOfUser = FindStringWithSmallestSum(userArray);
Console.WriteLine($"Номер строки с минимальной суммой элементов: {resultOfUser} строка");
Console.WriteLine();
