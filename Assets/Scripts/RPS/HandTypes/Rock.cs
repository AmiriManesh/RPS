public class Rock : IHand
{
    public string GetName() => "Rock";

    public int PlayAgainst(IHand otherHand)
    {
        if (otherHand is Rock) return 0; // Draw
        else if (otherHand is Scissors) return 1; // Rock beats Scissors
        else if (otherHand is Paper) return -1; // Rock loses to Paper

        return -1; // Default lose
    }
}