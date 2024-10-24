public class Paper : IHand
{
    public string GetName() => "Paper";

    public int PlayAgainst(IHand otherHand)
    {
        if (otherHand is Paper) return 0; // Draw
        else if (otherHand is Rock) return 1; // Paper beats Rock
        else if (otherHand is Scissors) return -1; // Paper loses to Scissors

        return -1; // Default lose
    }
}