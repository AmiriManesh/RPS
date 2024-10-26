using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;  // Text UI to display the result
    public HandManager handManager;
    private IHand playerHand;
    private IHand computerHand;

    [SerializeField] private Player player;
    [SerializeField] private Bot bot;

    public bool startGame = false;

    private void Start()
    {
        resultText.text = "Choose your hand: Rock, Paper, or Scissors!";
    }

    public void ChooseHand(string handName)
    {
        if (!startGame) return;

            try
            {
                playerHand = handManager.CreateHand(handName);
                PlayGame();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
    }

    private void PlayGame()
    {
        // Generate a random hand for the computer
        computerHand = GetRandomHand();

        // Display the hands selected
        Debug.Log($"Player: {playerHand.GetName()} vs Computer: {computerHand.GetName()}");

        int gameResult = playerHand.PlayAgainst(computerHand);

        // Display the result
        switch (gameResult)
        {
            case 1:
                resultText.text = $"Player wins! {playerHand.GetName()} beats {computerHand.GetName()}!";
                ScoreBoardManager.Instance.AddScore(TurnSystem.Instance.player, 1);
                bot.Hit();
                break;
            case 0:
                resultText.text = $"It's a draw! Both chose {playerHand.GetName()} and {computerHand.GetName()}!";
                break;
            case -1:
                resultText.text = $"You lose, Bot wins! {computerHand.GetName()} beats {playerHand.GetName()}!";
                ScoreBoardManager.Instance.AddScore(TurnSystem.Instance.bot, 1);
                player.Hit();
                break;
        }
        CheckResult();
    }

    private void CheckResult()
    {
        if (player.score == 5)
            Debug.Log("Player wins");
        if (bot.score == 5)
            Debug.Log("Bot Wins");
    }

    private IHand GetRandomHand()
    {
        var registeredHands = handManager.GetRegisteredHandNames();
        int randomIndex = UnityEngine.Random.Range(0, registeredHands.Count);
        return handManager.CreateHand(registeredHands[randomIndex]);
    }
}
