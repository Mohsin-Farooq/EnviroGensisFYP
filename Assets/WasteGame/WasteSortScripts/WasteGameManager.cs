using System.Collections;
using System.Collections.Generic;
using EnviroGenesis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteGameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private int lifeCount;
    public static WasteGameManager Instance;

     private int pointCount;
      private int erroCount;
    
   
    private void Awake()
    {
        RestartScoreValue();
       
    }

    public void Start()
    {
        Instance = this;
        gameOverUI.SetActive(false);
        Score.Instance.StartScore();
    }

    #region Reset Score Value

    private void RestartScoreValue()
    {
        erroCount = 0;
        pointCount = 0;
    }

    public int GetErroScoreValue()
    {
        return erroCount;
    }
    public int GetLifeScoreValue()
    {
        return lifeCount;
    }

    public int GetPointScoreValue()
    {
        return pointCount;
    }

    #endregion



    public void Resume()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Fail);
        }
        gameOverUI.SetActive(true);

        int score = Score.Instance.GeTPointScore();
        PlayerCharacterAttribute.instance.AddAttribute(AttributeType.Health,score);
    }

    public void ReloadLevel()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        RestartScoreValue();
        Resume();
    }

    public void openSetting()
    {
        if(settingPanel != null)
        {
            if(GeneralAudioManager.Instance != null)
            {
                GeneralAudioManager.Instance.PlaySound(SoundType.Click);
            }
            settingPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void closeSetting()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }
        if (settingPanel != null)
        {
            settingPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void GameRun()   
    {
        Resume();
    }
}
