using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Matrices matrices = new Matrices();
            
            Console.WriteLine("Draw out the matrix: \n\"#\" for life\n\" \" for dead\n\",\" for a new line");
            var enteredMatrix = "#    #   #,###   ##  ,##  ##  ##, # # # #, # # ###, ###";//Console.ReadLine();
            
            //#    #   #,###   ##  ,##  ##  ##, # # # #, # # ###, ###
            if (string.IsNullOrEmpty(enteredMatrix)) return;
            
            enteredMatrix = Regex.Replace(enteredMatrix, "[^# ,]+", "");
            enteredMatrix = enteredMatrix.Replace(",", "");
            
            var matrix = new int[Constants.MatrixRows, Constants.MatrixColumns];
            
            int row = 0, column = 0;
            
            foreach (var character in enteredMatrix)
            {
                if (character == ',' || column >= 10)
                {
                    row++;
                    column = 0;
                }

                matrix[row, column] = TurnCharacterToInt(character);
                column++;
            }

            Console.WriteLine("Entered Matrix:");
            matrices.PrintMatrix(matrix);
            Console.WriteLine(matrices.CountNeighbors(matrix, 0, 0));
        }

        private static int TurnCharacterToInt(char character)
        {
            if (character == ' ') return 0;
            if (character == '#') return 1;
            
            return -1;
        }
    } 
    /*
     Rules:
     If a cell is alive and has <= 1 neighbors: die
     If a cell is alive nad has 4>= neighbors: die
     If a cell is dead and has 3 neighbors: alive
     If a dead cell has 2 neighbors or 3 and alive: nothing
     */
}