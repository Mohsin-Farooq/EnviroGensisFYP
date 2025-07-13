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

    
    public void ActivateGameOverPanel()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Success);
        }
        GameOverPanel.SetActive(true);
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