using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TutorialCarousel : MonoBehaviour
{
    public Image tutorialImage;
    public Sprite[] tutorialSprites;
    public Button leftButton;
    public Button rightButton;
    public Transform dotContainer;
    public GameObject dotPrefab;

    private int currentIndex = 0;
    private List<GameObject> dots = new List<GameObject>();

    void Start()
    {
        SetupDots();
        UpdateUI();

        leftButton.onClick.AddListener(GoLeft);
        rightButton.onClick.AddListener(GoRight);
    }

    void SetupDots()
    {
        foreach (Transform child in dotContainer)
            Destroy(child.gameObject);

        dots.Clear();

        for (int i = 0; i < tutorialSprites.Length; i++)
        {
            GameObject dot = Instantiate(dotPrefab, dotContainer);
            dots.Add(dot);
        }
    }

    void UpdateUI()
    {
        tutorialImage.sprite = tutorialSprites[currentIndex];

        // Update button interactability
        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex < tutorialSprites.Length - 1;

        // Update dots
        for (int i = 0; i < dots.Count; i++)
        {
            dots[i].GetComponent<Image>().color = (i == currentIndex) ? Color.white : Color.gray;
        }
    }

    public void GoLeft()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateUI();
        }
    }

    public void GoRight()
    {
        if (currentIndex < tutorialSprites.Length - 1)
        {
            currentIndex++;
            UpdateUI();
        }
    }
}