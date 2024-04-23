public class HumanPlayer: Player
{
 public HumanPlayer(char symbol) : base(symbol) { }
    public override Move MakeMove(Board board)
    {
        while (true)
        {
            try
            {
                Console.Write("Enter cell number (1-9): ");
                int cellNum = int.Parse(Console.ReadLine()) -1;
                // if (board.IsCellEmpty(cellNum))
                if (cellNum >= 0 && cellNum < 9 && board.IsCellEmpty(cellNum) )
                {
                    return new Move(cellNum,_symbol);
                }
                else
                {
                    Console.WriteLine("Cell is not empty");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}