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
            Console.Clear();
            _board.Render();
            Console.WriteLine();
            Console.WriteLine(
                $"{(_board.CurrentMarker == 'X' 
                ? _playerXName : _playerOName)}:s ({_board.CurrentMarker}) tur");

            int move = 0;
            
            string moveAsString = Console.ReadLine()!;
            int.TryParse(moveAsString, out move);
            if(move != 0 && _board.PlaceMarker(move)) { break; }

            Console.Read();
        }
    }
}