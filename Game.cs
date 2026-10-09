class Game
{
    private Board _board;
    private string _playerXName = "";
    private string _playerOName ="";


    public Game()
    {
        _board = new Board();
        AskForNames();
        MainGameLoop();
    }

    private void AskForNames()
    {
        Console.WriteLine("Välkommen till Tic Tac Toe");
        Console.WriteLine("För att skapa en dum datorspelare lägg till * i någons namn.");
        Console.WriteLine("För att skapa en smart datorspelare lägg till + i någons namn.");
        Console.Write("Spelare X:s namn: ");
        _playerXName = Console.ReadLine()!;
        Console.Write("Spelare O:s namn: ");
        _playerOName = Console.ReadLine()!;
    }

    private void MainGameLoop()
    {
        while (true) // break this outer loop when someone wins
        {
            string? currentPlayer = 
            _board.CurrentMarker == 'X'
            ? _playerXName : _playerOName;

            // check if the player is stupid bot
            if (currentPlayer!.Contains('*'))
            {
                StupidBot.MakeMove(_board);
            }
            else if (currentPlayer!.Contains('+'))
            {
                SmartBot.MakeMove(_board);
            }
            //human
            else
            {
                while (true) // break this loop when someone makes a valid move
                {
                    Console.Clear();
                    _board.Render();
                    Console.WriteLine();
                    Console.WriteLine(
                        $"{currentPlayer}:s ({_board.CurrentMarker}) tur");

                    int move = 0;
                    
                    string moveAsString = Console.ReadLine()!;

                    int.TryParse(moveAsString, out move);
                    if(move != 0 && _board.PlaceMarker(move)) { break; }
                }
            }
            // Check for win or tie
        Console.Clear();

        _board.Render();

        if (WinCheck.CheckIsWin(_board, 'X'))
        {
            Console.WriteLine($"{_playerXName} vann!");
            break;
        }
        if (WinCheck.CheckIsWin(_board, 'O'))
        {
            Console.WriteLine($"{_playerOName} vann!");
            break;
        }
        else if (WinCheck.IsTie(_board))
        {
            Console.WriteLine("Det blev oavgjort!");
            break;
        }
            
        }
    }
}