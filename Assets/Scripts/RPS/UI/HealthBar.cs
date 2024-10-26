using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float lostHealth = 0.2f;

    public void LostHealthAnimation()
    {
        healthBar.fillAmount -= lostHealth;
    }
}
