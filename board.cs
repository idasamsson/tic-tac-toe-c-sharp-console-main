class Board
{
    //a "jagged" two-dimensional array in C#
   private char[][] _board =
   {
       [' ',' ',' '],
       [' ','X',' '],
       [' ',' ','O']
   };


public void Render()
    {
        foreach(char[] row in _board)
        {
            foreach(char cell in row)
            {
                Console.Write(cell);
            }
            Console.WriteLine();
        }

    }


}