class Game
{
    private Board _board;
    private string playerXName;
    private string playerOName;


    public Game()
    {
        _board = new Board();
        AskForNames();
    }

    private void AskForNames()
    {
        Console.WriteLine("Välkommen till Tic Tac Toe");
        Console.Write("Spelare X:s namn: ");
        playerXName = Console.ReadLine()!;
        Console.Write("Spelare O:s namn: ");
        playerOName = Console.ReadLine()!;
    }

    private void MainGameLoop()
    {
        while (true)
        {
            while (true)
            {
                Console.Clear();
                _board.Render();
                Console.WriteLine();
                Console.WriteLine(
                    $"{(_board.CurrentMarker == 'X' 
                    ? playerXName : playerOName)}:s ({_board.CurrentMarker}) tur");

                int move = 0;
                
                string moveAsString = Console.ReadLine()!;

                int.TryParse(moveAsString, out move);
                if(move != 0 && _board.PlaceMarker(move)) { break; }
            }
            // Check for win or tie
            if (WinCheck.CheckIsWin(_board, 'X'))
            {
                Console.WriteLine($"{playerXName} vann!");
                break;
            }
            else if (WinCheck.IsTie(_board))
            {
                Console.WriteLine($"{playerXName} vann!");
                break;
            }
            
        }
    }
}