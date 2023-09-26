using System;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var matrices = new Matrices();
            
            Console.WriteLine("Draw out the matrix: \n\"#\" for life\n\" \" for dead\n\",\" for a new line");
            var enteredMatrix = "#        #, #      # ,  #    #  ,   #  #   ,    ##    ,   #  #   ,  #    #  , #      # ,#        #";//"#    #   #,###   ##  ,##  ##  ##, # # # #, # # ###, ###";//Console.ReadLine();
            
            if (string.IsNullOrEmpty(enteredMatrix)) return;
            
            enteredMatrix = Regex.Replace(enteredMatrix, "[^# ,]+", "");
            
            var matrix = new int[Constants.MatrixRows, Constants.MatrixColumns];
            
            int row = 0, column = 0;
            
            foreach (var character in enteredMatrix)
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
            matrices.PrintMatrix(matrix);

            for (var i = 1; i < 11; i++)
            {
                Console.WriteLine($"MATRIX ITERATION ({i}) : ");
                 matrices.PrintMatrix(matrices.NextMatrix(matrix));
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