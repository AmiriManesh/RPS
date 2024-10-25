using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;  // Text UI to display the result
    public HandManager handManager;
    private IHand playerHand;
    private IHand computerHand;

    private void Start()
    {
        resultText.text = "Choose your hand: Rock, Paper, or Scissors!";
    }

    public void ChooseHand(string handName)
    {
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
                resultText.text = $"You win! {playerHand.GetName()} beats {computerHand.GetName()}!";
                ScoreBoardManager.Instance.AddScore(TurnSystem.Instance.player, 1);
                break;
            case 0:
                resultText.text = $"It's a draw! Both chose {playerHand.GetName()}!";
                break;
            case -1:
                resultText.text = $"You lose! {computerHand.GetName()} beats {playerHand.GetName()}!";
                ScoreBoardManager.Instance.AddScore(TurnSystem.Instance.bot, 1);
                break;
        }
    }

    private IHand GetRandomHand()
    {
        var registeredHands = handManager.GetRegisteredHandNames();
        int randomIndex = UnityEngine.Random.Range(0, registeredHands.Count);
        return handManager.CreateHand(registeredHands[randomIndex]);
    }
}
