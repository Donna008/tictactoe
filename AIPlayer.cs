
public class AIPlayer : Player
{
    public AIPlayer(char symbol) : base(symbol) { }

    public override Move MakeMove(Board board)
    {
        int bestMove = GetBestMove(board);
        return new Move(bestMove, Symbol);
    }

    // public Move MakeMove(Board board)
    // {
    //     int bestMove = GetBestMove(board);
    //     return new Move(bestMove, Symbol);
    // }

    private int GetBestMove(Board board)
    {
        int bestScore = int.MinValue;
        int bestMove = -1;

        // Iterate through all empty cells
        for (int i = 0; i < 9; i++)
        {
            if (board.IsCellEmpty(i))
            {
                // Make the move
                board.UpdateCell(i, Symbol);
                // Call Minimax recursively with the opposite player's symbol
                int score = Minimax(board, 0, false, GetOpponentSymbol());
                // Undo the move
                board.UpdateCell(i, ' ');
                // Update the best move if needed
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }
        return bestMove;
    }

    private int Minimax(Board board, int depth, bool isMaximizingPlayer, char opponentSymbol)
    {
        // Base case: If the game is over or depth limit is reached, return the score
        if (board.IsWinner(Symbol))
        {
            return 10;
        }
        else if (board.IsWinner(opponentSymbol))
        {
            return -10;
        }
        else if (board.IsFull())
        {
            return 0;
        }

        // If it's the maximizing player's turn
        if (isMaximizingPlayer)
        {
            int bestScore = int.MinValue;
            // Iterate through all empty cells
            for (int i = 0; i < 9; i++)
            {
                if (board.IsCellEmpty(i))
                {
                    // Make the move
                    board.UpdateCell(i, Symbol);
                    // Call Minimax recursively with the opposite player's symbol
                    int score = Minimax(board, depth + 1, false, opponentSymbol);
                    // Undo the move
                    board.UpdateCell(i, ' ');
                    // Update the best score
                    bestScore = Math.Max(bestScore, score);
                }
            }
            return bestScore;
        }
        // If it's the minimizing player's turn
        else
        {
            int bestScore = int.MaxValue;
            // Iterate through all empty cells
            for (int i = 0; i < 9; i++)
            {
                if (board.IsCellEmpty(i))
                {
                    // Make the move
                    board.UpdateCell(i, opponentSymbol);
                    // Call Minimax recursively with the opposite player's symbol
                    int score = Minimax(board, depth + 1, true, opponentSymbol);
                    // Undo the move
                    board.UpdateCell(i, ' ');
                    // Update the best score
                    bestScore = Math.Min(bestScore, score);
                }
            }
            return bestScore;
        }
    }

    // Helper method to get the opponent's symbol
    private char GetOpponentSymbol()
    {
        return Symbol == 'X' ? 'O' : 'X';
    }
}