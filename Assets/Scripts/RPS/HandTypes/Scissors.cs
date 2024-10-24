public class Scissors : IHand
{
    public string GetName() => "Scissors";

    public int PlayAgainst(IHand otherHand)
    {
        if (otherHand is Scissors) return 0; // Draw
        else if (otherHand is Paper) return 1; // Scissors beats Paper
        else if (otherHand is Rock) return -1; // Scissors loses to Rock

        return -1; // Default lose
    }
}