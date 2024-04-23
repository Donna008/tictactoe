public class Board
{
    private List<char> _cells;
    public Board() 
    {
        _cells = new List<char>();
        for (int i = 0; i < 9; i++)
        {
            _cells.Add(' ');
        }
    }

    public void Display()
    {
        Console.WriteLine($"\n {_cells[0]} | {_cells[1]} | {_cells[2]}");
        Console.WriteLine("- - - - - -");
        Console.WriteLine($" {_cells[3]} | {_cells[4]} | {_cells[5]}");
        Console.WriteLine("- - - - - -");
        Console.WriteLine($" {_cells[6]} | {_cells[7]} | {_cells[8]}");
    }

    public void UpdateCell(int cellNum, char symbol)
    {
        _cells[cellNum] = symbol;
    }

    public bool IsCellEmpty(int cellNum)
    {
        return _cells[cellNum] == ' ';
    }

    public bool IsFull()
    {
        return !_cells.Contains(' ');
    }

    public bool IsWinner(char symbol)
    {
        int[,] winningCombinations = new int[8,3]
        {
            {0,1,2},{3,4,5},{6,7,8},
            {0,3,6},{1,4,7},{2,5,8},
            {0,4,8},{2,4,6}
        };
        
        for (int i = 0; i < 8; i++ )
        {
            if (_cells[winningCombinations[i,0]] == symbol &&
                _cells[winningCombinations[i,1]] == symbol &&
                _cells[winningCombinations[i,2]] == symbol)
            {
                return true;
            }
        }
        return false;
    }
}