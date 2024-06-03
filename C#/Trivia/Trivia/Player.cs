namespace Trivia;

public class Player(string name)
{
    private int _place;
    private int _purse;
    private bool _inPenaltyBox;

    public int GetPlace()
    {
        return _place;
    }

    public int GetPurse()
    {
        return _purse;
    }

    public string GetName()
    {
        return name;
    }

    public bool IsInPenaltyBox()
    {
        return _inPenaltyBox;
    }

    public void MovePlace(int roll)
    {
        _place += roll;
        if (_place > 11)
            _place -= 12;
    }

    public void AddCoin()
    {
        _purse++;
    }

    public void PutInJail()
    {
        _inPenaltyBox = true;
    }
}
