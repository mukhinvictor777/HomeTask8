int[,] generate2DArray(int hight, int wight, int randomStart, int randomEnd)
{
    int[,] twoDArray = new int[hight, wight];
    for (int i = 0; i < twoDArray.GetLength(0); i++)
    {
        for (int j = 0; j < twoDArray.GetLength(1); j++)
        {
            twoDArray[i, j] = new Random().Next(randomStart, randomEnd + 1);
        }
    }
    return twoDArray;
}

void printColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(data);
    Console.ResetColor();
}

void print2DArray(int[,] arrayToPrint)
{
    Console.Write("\t");
    for (int i = 0; i < arrayToPrint.GetLength(1); i++)
    {
        printColorData(i + "\t");
    }
    Console.WriteLine();
    for (int i = 0; i < arrayToPrint.GetLength(0); i++)
    {
        printColorData(i + "\t");
        for (int j = 0; j < arrayToPrint.GetLength(1); j++)
        {
           Console.Write(arrayToPrint[i, j] + "\t"); 
        }
        Console.WriteLine();
    }
}

int[,] SortBigestToSmallest(int[,] incomingArray)
{
    int buffer = 0;
    for (int i = 0; i < incomingArray.GetLength(0); i++)
    {
        for (int j = 0; j < incomingArray.GetLength(1); j++)
        {
            for (int k = 0; k < incomingArray.GetLength(1); k++)
            {
                if (incomingArray[i,j] > incomingArray[i,k])
                {
                    buffer = incomingArray[i,j];
                    incomingArray[i,j] = incomingArray[i,k];
                    incomingArray[i,k] = buffer;
                }
            }
        }
    }
    
    return incomingArray;
}


int[,] generatedArray = generate2DArray(15, 6, -10, 10);
Console.WriteLine();
print2DArray(generatedArray);
Console.WriteLine();
int[,] userArray =  {
                        {1, 4, 7, 2},
                        {5, 9, 2, 3},
                        {8, 4, 2, 4}
                    };
print2DArray(userArray);
Console.WriteLine();
int[,] sortedArray = SortBigestToSmallest(userArray);
print2DArray(userArray);
Console.WriteLine();
int[,] sortedRandomArray = SortBigestToSmallest(generatedArray);
print2DArray(generatedArray);
Console.WriteLine();