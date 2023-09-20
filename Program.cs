using System;
using System.Runtime.InteropServices;

namespace GameOfLife
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Draw out the matrix: \n\"#\" for life\n\" \" for dead\n\",\" for a new line");
            
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