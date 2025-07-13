using EnviroGenesis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    public static UiManager instance;

    private void Awake()
    {
        instance = this;
    }

    private int points = 0;
    public void ActivateGameOverPanel()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Success);
        }
        GameOverPanel.SetActive(true);
        points += 5;
        PlayerCharacterAttribute.instance.AddAttribute(AttributeType.Hunger,points);
       
    }

    public void DeactivateGameOverPanel()
    {
        GameOverPanel.SetActive(false);
    }

    public void OnClickHome()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }
        SceneManager.LoadScene((int)SceneIndex.SeedMenu);
    }
}