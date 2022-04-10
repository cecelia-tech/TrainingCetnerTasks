using Task01._2;

Console.WriteLine("Diagonal Matrix:");
DiagonalMatrix<short> shortDiagonalMatrix = new DiagonalMatrix<short>(3);

//Console.WriteLine(shortDiagonalMatrix.ToString());

shortDiagonalMatrix[1, 1] = 5;
shortDiagonalMatrix[1, 1] = 5;
shortDiagonalMatrix[0, 2] = 4;

Console.WriteLine(shortDiagonalMatrix.ToString());

/*Console.WriteLine("Square matrix:");
SquareMatrix<int> s = new SquareMatrix<int>(3);
s[1, 1] = 5;
s[2, 2] = 6;
s[2, 2] = 6;
Console.WriteLine(s.ToString());
*/

/*foreach (var item in shortDiagonalMatrix)
{
    Console.WriteLine(item);
}*/