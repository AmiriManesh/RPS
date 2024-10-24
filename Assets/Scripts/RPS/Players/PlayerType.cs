using UnityEngine;

public class PlayerType : MonoBehaviour
{
    public string playerName;
    public int score;
    public PlayerType(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}
