public class Player : PlayerType
{
    private HealthBar healthbar;
    private void Start()
    {
        GetComps();
    }

    public Player(string playerName, int score) : base(playerName, score)
    {

    }
    public override void Hit()
    {
        base.Hit();
        healthbar.LostHealthAnimation();
    }

    private void GetComps()
    {
        healthbar = GetComponent<HealthBar>();
    }
}
