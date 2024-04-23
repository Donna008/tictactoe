public abstract class Player
{
    protected char _symbol;
    public Player(char symbol)
    {
        _symbol = symbol;
    }

    public abstract Move MakeMove(Board board);
    public char Symbol => _symbol;
}