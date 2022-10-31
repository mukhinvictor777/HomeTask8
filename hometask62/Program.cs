int getNumberFromUser(string userInformation)
{
    int  result = 0;
    while (result == 0 || result < 0)
    {
        Console.Write(userInformation);
        string userLine = Console.ReadLine();
        int.TryParse(userLine, out result);
        if (result == 0 || result < 0) Console.WriteLine($"Введите целое положительное число, вы вввели {userLine}"); 
        else break;
    }
    return result;
}

int[] GetRandomArray(int count, int startValue, int endValue)
{
    int arrayLenght = count * count;
    int[] generatedArray = new int[arrayLenght];
    if (arrayLenght > endValue - startValue + 1)
    {
        return generatedArray;
    }
    else
    {
        generatedArray[0] = new Random().Next(startValue, endValue+1);
        for (int i = 1; i < arrayLenght; i++)
        {
            generatedArray[i] = new Random().Next(startValue, endValue+1);
            for (int j = 0; j < i; j++)
            {
                while (generatedArray[i] == generatedArray[j])
                {
                    generatedArray[i] = new Random().Next(startValue, endValue+1);
                    j = 0;
                }
            }
        }
    return generatedArray;
    }
}

int[] SortArray(int[] incomingArray)
{
    int buffer = 0;
    for (int i = 0; i < incomingArray.Length; i++)
    {
        for (int j = 0; j < incomingArray.Length; j++)
        {
            if (incomingArray[j] > incomingArray[i])
            {
                buffer = incomingArray[i];
                incomingArray[i] = incomingArray[j];
                incomingArray[j] = buffer;
            }
        }
    }
    return incomingArray;
}

void printColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(data);
    Console.ResetColor();
}

void printArray (int[] incomingArray)
{
    printColorData("Сформерована последовательность из случайных неповторяющихся чисел:");
    Console.Write("[ ");
    for (int i = 0; i < incomingArray.Length; i++)
    {
        Console.Write($"{incomingArray[i]} ");
    }
    Console.Write("]");
    Console.WriteLine();
}

void print2DArray(int[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Console.Write($"{inputArray[i,j]} \t");
        }
        Console.WriteLine();
    }
}

int[,] GetSpiralFromGeneratedArray(int[] incomingArray)
{
    double spiralLength = Math.Sqrt(incomingArray.Length);
    int length = Convert.ToInt32(spiralLength);
    int[,] spiral = new int[length, length];
    int count = 0;
    int len = length;
    for (int i = 0; i < length / 2 + length % 2; i++)
    {
        for (int j = 0; j < len; j++)
        {
            spiral[i, i+j] = incomingArray[count];
            count++;
        }
        for (int j = 1; j < len; j++)
        {
            spiral[i+j, length - i- 1] = incomingArray[count];
            count++;
        }
        len = len - 2;
        for (int j = len; j >= 0; j--)
        {
            spiral[length-i-1, i + j] = incomingArray[count];
            count++;
        }
        for (int j = len; j >= 1; j--)
        {
            spiral[i+j, i] = incomingArray[count];
            count++;
        }
    }
    return spiral;
}

Console.Write($"Введите ширину спирали: ");
int spiralWidth = getNumberFromUser("");
Console.WriteLine();
Console.Write($"Введите минимально возможное значение в спирали: ");
int startValue = getNumberFromUser("");
Console.WriteLine();
Console.Write($"Введите максимально возможное значение в спирали: ");
int endValue = getNumberFromUser("");
Console.WriteLine();
int[] randomArray = GetRandomArray(spiralWidth, startValue, endValue);
printArray(randomArray);
int[] sortedArray = SortArray(randomArray);
printArray(sortedArray);
int[,] spiral = GetSpiralFromGeneratedArray(sortedArray);
print2DArray(spiral);