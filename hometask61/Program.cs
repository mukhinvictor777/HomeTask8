void CreateTriangle(int[,] triangle, int size)
{
    for (int i = 0; i < size; i++)
    {
        triangle[i, 0] = 1;
        triangle[i, i] = 1;
    }

    for (int i = 2; i < size; i++)
    {
        for (int j = 1; j < i; j++)
        {
            triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
        }
    }
}

void printColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(data);
    Console.ResetColor();
}

void PrintIsoscelesTriangle(int[,] triangle)
{
    int size = triangle.GetLength(0);
    const int cellWidth = 4;
    int col = cellWidth * size;
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j <= i; j++)
        {
           Console.SetCursorPosition(col, i + 2);
           if (triangle[i, j] != 0 ) printColorData($"{triangle[i, j],cellWidth}");
           col = col + cellWidth * 2;
        }
        col = cellWidth * size - cellWidth * (i + 1);
        Console.WriteLine();
    }
    Console.WriteLine();
}
int size = 20;
int[,] triangle = new int[size, size];
CreateTriangle(triangle, size);
PrintIsoscelesTriangle(triangle);