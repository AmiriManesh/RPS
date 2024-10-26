using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage background_IMG;
    [SerializeField] private float x, y;
    
    private void Update()
    {
        background_IMG.uvRect = new Rect(background_IMG.uvRect.position + new Vector2(x, y) * Time.deltaTime, background_IMG.uvRect.size);
    }
}
