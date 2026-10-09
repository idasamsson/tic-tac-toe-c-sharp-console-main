using System.Reflection.Metadata.Ecma335;

class Board
{
    //a "jagged" two-dimensional array in C#
   private char[][] _board =
   {
       [' ',' ',' '],
       [' ',' ',' '],
       [' ',' ',' ']
   };

   //current player/marker
    private char _currentMarker = 'X';
    public char CurrentMarker
    {
    get { return _currentMarker; }
    }

    public char [][] Matrix
    {
        get { return Matrix; }
    }

public void Render()
    {
        Console.WriteLine("-------------");

         int counter = 1;
        foreach(char[] row in _board)
        {
            foreach(char cell in row)
            {
                Console.Write($"| {(cell == ' ' ? counter : cell.ToString())} ");
                counter++;
            }
            Console.WriteLine("|");
            Console.WriteLine("-------------");
        }
    }
    public bool PlaceMarker(int row, int col)
    {
        //if the board position isn't empty or the marker char isn't X or O
        if(_board[row][col] != (' '))
        { return false;}

        // the move is ok - updat the board
        _board[row][col] = _currentMarker;

        // toggle marker color
        _currentMarker = _currentMarker == 'X' ? 'O' : 'X';
        return true;
    }
    public bool PlaceMarker(int position /* 1 to 9 */)
    {
        if(position < 1 || position > 9)
        {
            return false;
        }
        position -= 1;
        int row = position / 3;
        int col = position % 3;
        return PlaceMarker(row, col);
    }
}


