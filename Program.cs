using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new int[Constants.MatrixRows, Constants.MatrixColumns];
            var enteredMatrix = ",,,,,#########,,,,,";//  ",    #,    #,   #,   #,   #,   #,    #,   #,   #,   #";// "#        #, #      # ,  #    #  ,   #  #   ,    ##    ,   #  #   ,  #    #  , #      # ,#        #";
            
            enteredMatrix = Regex.Replace(enteredMatrix, "[^# ,]+", "");
            
            int row = 0, column = 0;
            
            foreach (var character in enteredMatrix.Where(character => row <= 9))
            {
                if (character == ',' || column >= 10)
                {
                    row++;
                    column = 0;
                    continue; 
                }

                matrix[row, column] = TurnCharacterToInt(character);
                column++;
            }

            Console.WriteLine("Entered Matrix:");
            Matrices.PrintMatrix(matrix);

            for (var i = 1; i < 11; i++)
            {
                Console.WriteLine($"MATRIX ITERATION ({i}) : "); 
                Matrices.PrintMatrix(Matrices.NextMatrix(matrix));
            }
        }

        private static int TurnCharacterToInt(char character)
        {
            switch (character)
            {
                case ' ':
                    return 0;
                case '#':
                    return 1;
                default:
                    return -1;
            }
        }
    } 
}