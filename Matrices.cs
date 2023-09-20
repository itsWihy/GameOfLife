namespace GameOfLife
{
    public class Matrices
    {
        int gameRows;
        int gameColumns;

        public Matrices(int gameSize, int gameColumns)
        {
            this.gameColumns = gameColumns;
            this.gameRows = gameSize;
        }

        public int[,] CreateMatrix()
        {
            var matrix = new int[gameRows, gameColumns];
            return matrix;
        }
    }
}