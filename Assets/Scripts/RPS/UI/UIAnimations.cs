using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimations : MonoBehaviour
{
    [Header("Intro GameObjects/Img")]
    [SerializeField] private RectTransform VersusIntro;
    [SerializeField] private RectTransform playerName;
    [SerializeField] private RectTransform botName;
    [SerializeField] private Transform versusImageTransform;
    [SerializeField] private Image versus_Img;

    [Header("Intro Variables")]
    [SerializeField] private float delayForBlackScreen = 1.5f;

    private void Start()
    {
        ShowIntro();
    }

    private void ShowIntro()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(playerName.DOAnchorPosX(0f, 0.5f).SetEase(Ease.InOutCubic));
        sequence.Join(botName.DOAnchorPosX(0f, 0.5f).SetEase(Ease.InOutCubic));

        // Set initial transparency and scale
        versus_Img.color = new Color(versus_Img.color.r, versus_Img.color.g, versus_Img.color.b, 0);
        versusImageTransform.localScale = Vector3.zero;

        // Create a sequence to play animations together
        sequence.Append(versusImageTransform.DOScale(1.25f, 0.35f).SetEase(Ease.OutBack)); // Scale up
        sequence.Join(versus_Img.DOFade(1f, 0.35f)); // Fade in at the same time
        sequence.AppendInterval(delayForBlackScreen);

        sequence.OnComplete(() =>
        {
            sequence.Kill();// Remove sequence from memeory
            VersusIntro.gameObject.SetActive(false);
        });
    }
}
