using System;

namespace GameOfLife
{
    public abstract class Matrices
    {
        public static void PrintMatrix(int[,] matrix)
        {
            var matrixSize = matrix.Length / Math.Sqrt(matrix.Length);

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    var value = matrix[i, j].ToString().Replace("0", " ").Replace("1", "#");

                    Console.Write(value);
                }

                Console.WriteLine();
            }
        }

        public static int[,] NextMatrix(int[,] matrix)
        {
            var originalMatrix = (int[,])matrix.Clone();
            
            for (var i = 0; i < Constants.MatrixRows; i++)
            {
                for (var j = 0; j < Constants.MatrixColumns; j++)
                {
                    var neighbors = CountNeighbors(originalMatrix, i, j);
                    matrix[i, j] = LivingState(neighbors, originalMatrix[i, j]);
                }
            }
            return matrix;
        }

        private static int LivingState(int neighbors, int state)
        {
            if (state != 1) return neighbors == 3 ? 1 : 0;
            
            if (neighbors < 2 || neighbors > 3) 
                return 0;

            return 1;
        }

        private static int CountNeighbors(int[,] matrix, int row, int column)
        {
            var neighbors = 0;
            
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                { 
                    if(row+i < 0 || row+i > Constants.MatrixRows-1 || column+j < 0 || column+j > Constants.MatrixColumns-1) continue; 
                    
                    if(i == 0 && j == 0) continue;
                    if(matrix[row + i, column + j] != 1) continue;

                    neighbors++;
                }
            }
          
            return neighbors;
        }
    }
}