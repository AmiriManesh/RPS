using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{

    [SerializeField] private RectTransform loadingScreen;
    [Header("Black Screen Variables")]
    [SerializeField] private float destination = 1090f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float wait_Time = 1.35f;
    [Header("HealthBar")]
    [SerializeField] private GameObject HealthBar;
    [Header("Buttons")]
    [SerializeField] private GameObject Buttons;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(wait_Time);
        BlackScreenTransition();
    }
    private void BlackScreenTransition()
    {
        loadingScreen.DOAnchorPos(new Vector2(destination, loadingScreen.anchoredPosition.y), duration).SetEase(Ease.OutQuad).
            OnComplete( () => 
            { 
                HealthBar.SetActive(true);
                Buttons.SetActive(true);
            });
    }
}
