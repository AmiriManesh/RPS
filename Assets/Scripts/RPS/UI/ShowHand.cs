using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHand : MonoBehaviour
{
    [SerializeField] private List<RectTransform> buttons = new List<RectTransform>();
    [SerializeField] private GameManager gameManager;
    private void OnEnable()
    {
        foreach (var item in buttons)
        {
            item.localScale = Vector3.zero;
        }
        ShowhandSelection();
    }

    private void ShowhandSelection()
    {
        Sequence sequence = DOTween.Sequence();
        foreach (var item in buttons)
        {
            item.gameObject.SetActive(true);
            sequence.Append(item.DOScale(1f, 0.35f).SetEase(Ease.InQuad));
            sequence.AppendInterval(0.75f);
        }
        sequence.OnComplete(() =>
        {
            gameManager.startGame = true;
        });
    }
}
