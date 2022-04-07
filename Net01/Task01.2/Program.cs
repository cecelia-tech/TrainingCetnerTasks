using Task01._2;

DiagonalMatrix<short> shortDiagonalMatrix = new DiagonalMatrix<short>(3);

for (int i = 0; i < shortDiagonalMatrix.Size; i++)
{
    Console.WriteLine(shortDiagonalMatrix[i, i]);
}

shortDiagonalMatrix[1, 1] = 5;

for (int i = 0; i < shortDiagonalMatrix.Size; i++)
{
    Console.WriteLine(shortDiagonalMatrix[i, i]);
}
