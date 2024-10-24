// Initialize the factory and register hand types
using UnityEngine;

public class RegisterManager : MonoBehaviour
{
    private GameManager gameManager;
    private HandManager handManager = new HandManager();
    private void Start()
    {
        RegisterTypes(handManager);
        GetComps();
        SendHandManager();
    }

    public void RegisterTypes(HandManager handManager)
    {
        handManager.RegisterHand("Rock", typeof(Rock));
        handManager.RegisterHand("Paper", typeof(Paper));
        handManager.RegisterHand("Scissors", typeof(Scissors));
    }
    private void SendHandManager()
    {
        gameManager.handManager = handManager;
    }
    private void GetComps()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
}
