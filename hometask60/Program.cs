int[,,] GenerateUnique3DRandomArray(int indexI, int indexJ, int indexK, int srartValue, int endValue)
{
    int countOfElementsInArray = indexI * indexJ * indexK;
    int[,,] generatedArray = new int[indexI,indexJ,indexK];
    if (countOfElementsInArray > (endValue - srartValue + 1)*2)
    {
        return generatedArray;
    }
    else
    {
        int[] uniqueRandomNubers = new int[countOfElementsInArray];
        uniqueRandomNubers[0] = new Random().Next(srartValue, endValue+1)*(new Random().Next(0,2) * 2 - 1);
        for (int i = 1; i < countOfElementsInArray; i++)
        {
            uniqueRandomNubers[i] = new Random().Next(srartValue, endValue+1)*(new Random().Next(0,2) * 2 - 1);
            for (int j = 0; j < i; j++)
            {
                while (uniqueRandomNubers[i]==uniqueRandomNubers[j])
                {
                    uniqueRandomNubers[i] = new Random().Next(srartValue, endValue+1)*(new Random().Next(0,2) * 2 - 1);
                    j=0;
                }
            }
        }
        int indexInRandomArray = 0;       
        for (int i = 0; i < generatedArray.GetLength(0); i++)
        {
            for (int j = 0; j < generatedArray.GetLength(1); j++)
            {
                for (int k = 0; k < generatedArray.GetLength(2); k++)
                {
                    generatedArray[i,j,k] = uniqueRandomNubers[indexInRandomArray];
                    indexInRandomArray++;
                }
            }
        }
    return generatedArray;
    }
}

void Print3DArray(int[,,] incomingArray)
{
    if (incomingArray[0,0,0] == 0)
    {
        Console.WriteLine($"Массив размером {incomingArray.GetLength(0)} x {incomingArray.GetLength(1)} x {incomingArray.GetLength(2)} невозможно заполнить уникальными двузначными числами.");
        Console.WriteLine("Сократите число элементов или увеличьте диапазон значений для генерации элементов.");
    }
    else
    {   
        Console.WriteLine($"Массив размером {incomingArray.GetLength(0)} x {incomingArray.GetLength(1)} x {incomingArray.GetLength(2)}");
        for (int i = 0; i < incomingArray.GetLength(0); i++)
        {
            for (int j = 0; j < incomingArray.GetLength(1); j++)
            {
                for (int k = 0; k < incomingArray.GetLength(2); k++)
                {
                    Console.WriteLine($"\t{incomingArray[i,j,k]}\t({i},{j},{k})");
                }
            }
        }
    }
}

Console.WriteLine();
int[,,] generatedArray = GenerateUnique3DRandomArray(5, 5, 5, 10, 99);
Print3DArray(generatedArray);
Console.WriteLine();