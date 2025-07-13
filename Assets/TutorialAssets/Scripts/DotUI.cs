using UnityEngine;
using UnityEngine.UI;

public class DotUI : MonoBehaviour
{
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    private Image dotImage;

    private void Awake()
    {
        dotImage = GetComponent<Image>();
    }

    public void SetSelected(bool isSelected)
    {
        if (dotImage != null)
            dotImage.sprite = isSelected ? selectedSprite : unselectedSprite;
    }
}