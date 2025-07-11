using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteGameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject settingPanel;
    public static WasteGameManager Instance;

    private int pointCount;
    private int erroCount;
    private int lifeCount;
   
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
        lifeCount = 7;
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
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void ReloadLevel()
    {
        //EditorSceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        RestartScoreValue();
        Resume();
    }

    public void openSetting()
    {
        if(settingPanel != null)
        {
            settingPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void closeSetting()
    {
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
