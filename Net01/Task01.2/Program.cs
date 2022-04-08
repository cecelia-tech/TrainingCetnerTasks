using Task01._2;

DiagonalMatrix<short> shortDiagonalMatrix = new DiagonalMatrix<short>(3);

Console.WriteLine(shortDiagonalMatrix.ToString());

shortDiagonalMatrix[1, 1] = 5;

Console.WriteLine(shortDiagonalMatrix.ToString());



/*SquareMatrix<int> s = new SquareMatrix<int>(3);
s[1, 1] = 5;
s[2, 2] = 6;
Console.WriteLine(s.ToString());
*/