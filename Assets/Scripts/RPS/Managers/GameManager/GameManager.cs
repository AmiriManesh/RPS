using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;  // Text UI to display the result
    private HandFactory handFactory;
    private IHand playerHand;
    private IHand computerHand;

    private void Start()
    {
        // Initialize the factory and register hand types
        handFactory = new HandFactory();
        SetupRegisteredHands();
        resultText.text = "Choose your hand: Rock, Paper, or Scissors!";
    }

    private void SetupRegisteredHands()
    {
        handFactory.RegisterHand("Rock", typeof(Rock));
        handFactory.RegisterHand("Paper", typeof(Paper));
        handFactory.RegisterHand("Scissors", typeof(Scissors));
    }

    public void ChooseHand(string handName)
    {
        try
        {
            playerHand = handFactory.CreateHand(handName);
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
                break;
            case 0:
                resultText.text = $"It's a draw! Both chose {playerHand.GetName()}!";
                break;
            case -1:
                resultText.text = $"You lose! {computerHand.GetName()} beats {playerHand.GetName()}!";
                break;
        }
    }

    private IHand GetRandomHand()
    {
        var registeredHands = handFactory.GetRegisteredHandNames();
        int randomIndex = UnityEngine.Random.Range(0, registeredHands.Count);
        return handFactory.CreateHand(registeredHands[randomIndex]);
    }
}
