public interface IHand
{
    public string GetName();
    public int PlayAgainst(IHand otherHand);  // Returns 1 if win, 0 if draw, -1 if lose
}