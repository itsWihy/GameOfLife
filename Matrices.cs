using System;

namespace GameOfLife
{
    public class Matrices
    {
        public void PrintMatrix(int[,] matrix)
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

        public int CountNeighbors(int[,] matrix, int row, int column)
        {
            var neighbors = 0;
            
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                { 
                    if(row+i < 0 || row+i > Constants.MatrixRows || column+j < 0 || column+j > Constants.MatrixColumns) continue; 
                    
                    if(i == 0 && j == 0) continue;
                    if(matrix[row + i, column + j] != 1) continue;

                    neighbors++;
                }
            }
          
            return neighbors;
        }

        public int[,] NextMatrix(int[,] matrix)
        {
            var resultMatrix = matrix;
            
            for (int i = 0; i < Constants.MatrixRows; i++)
            {
                for (int j = 0; j < Constants.MatrixColumns; j++)
                {
                    //matrix
                }
            }
            //todo today. Loop over everything. Apply rules and CountNeighbors. Then replace. You'd need to make a copy to change from, and a matrix to return so they don't conflict.
            return resultMatrix;
        }

        private int LivingState(int neighbors, int state)
        {
            if (state != 1) return neighbors == 3 ? 1 : 0;
            
            if (neighbors < 2 || neighbors > 3) 
                return 0;

            return 1;
        }
        
        /*
             * If a cell is alive and has <= 1 neighbors: dies
               If a cell is alive and has 4>= neighbors: dies
               If a cell is dead and has 3 neighbors: lives
               If a cell is dead and has 2 neighbors: dies
               If a cell is alive and has 3 neighbors: lives
             */
    }
}