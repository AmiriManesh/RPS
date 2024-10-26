using UnityEngine;

public abstract class PlayerType : MonoBehaviour
{
    public string playerName;
    public int score;
    public int health= 5;
    public PlayerType(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }

    public virtual void Hit()
    {
        health--;
    }
}
