public class GameController
{
   private Board _board;
    private AIPlayer _player1; // Change Player to AIPlayer
    private AIPlayer _player2; // Change Player to AIPlayer
    private AIPlayer _currentPlayer; // Change Player to AIPlayer

    public GameController(Player player1, Player player2)
    {
        _board = new Board();
        _player1 = (AIPlayer)player1; // Explicit cast to AIPlayer
        _player2 = (AIPlayer)player2; // Explicit cast to AIPlayer
        _currentPlayer = _player1;
    }

    public void SwitchPlayers()
    {
        if (_currentPlayer == _player1)
        {
            _currentPlayer = _player2;
        }
        else
        {
            _currentPlayer = _player1;
        }
    }

    public bool IsGameOver()
    {
        return _board.IsWinner(_player1.Symbol) ||
               _board.IsWinner(_player2.Symbol) ||
               _board.IsFull();
    }

    public void Play()
    {
        while (!IsGameOver())
        {
            _board.Display();
            Console.WriteLine($"\nPlayer {_currentPlayer.Symbol}'s turn\n");
            Move move = _currentPlayer.MakeMove(_board);
            _board.UpdateCell(move.CellNum, move.Symbol);
            SwitchPlayers();
        }
        _board.Display();
        if(_board.IsWinner(_player1.Symbol))
        {
            Console.WriteLine("\nPlayer 1 wins\n");
        }
        else if (_board.IsWinner(_player2.Symbol))
        {
            Console.WriteLine("\nPlayer 2 wins\n");
        }
        else
        {
            Console.WriteLine("\nOops, no winner");
        }
    }
    
}