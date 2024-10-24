using System.Linq;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    public static ScoreBoardManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void AddScore(PlayerType playerType, int score)
    {
        playerType.score += score;
        SortScores();
    }

    private void SortScores()
    {
        TurnSystem.Instance.players = TurnSystem.Instance.players.OrderByDescending(s => s.score).ToList();
    }

    public void ResetScores()
    {
        foreach (PlayerType item in TurnSystem.Instance.players)
            item.score = 0;
    }
}
