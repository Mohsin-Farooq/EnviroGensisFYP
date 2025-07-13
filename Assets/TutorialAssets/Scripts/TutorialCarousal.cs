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
    private List<DotUI> dotUIs = new List<DotUI>();

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

        dotUIs.Clear();

        for (int i = 0; i < tutorialSprites.Length; i++)
        {
            GameObject dotGO = Instantiate(dotPrefab, dotContainer);
            DotUI dotUI = dotGO.GetComponent<DotUI>();
            dotUIs.Add(dotUI);
        }
    }

    void UpdateUI()
    {

        tutorialImage.sprite = tutorialSprites[currentIndex];

        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex < tutorialSprites.Length - 1;

        for (int i = 0; i < dotUIs.Count; i++)
        {
            dotUIs[i].SetSelected(i == currentIndex);
        }
    }

    public void GoLeft()
    {
        if (currentIndex > 0)
        {
            if (GeneralAudioManager.Instance != null)
            {
                GeneralAudioManager.Instance.PlaySound(SoundType.Click);
            }
            currentIndex--;
            UpdateUI();
        }
    }

    public void GoRight()
    {        
        if (currentIndex < tutorialSprites.Length - 1)
        {
            if (GeneralAudioManager.Instance != null)
            {
                GeneralAudioManager.Instance.PlaySound(SoundType.Click);
            }
            currentIndex++;
            UpdateUI();
        }
    }
}