using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void LoadSplashScreen()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.SplashScreen);
    }

    public void LoadWasteSortMenu()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.WasteSortMenu);
    }

    public void LoadWasteSortScene()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.WasteSortScene);
    }

    public void LoadQuizGame()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.QuizGame);
    }

    public void LoadSeedMenu()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.SeedMenu);
    }

    public void LoadSeedGame()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.SeedGame);
    }

    public void LoadRiverMenu()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.RiverMenu);
    }

    public void LoadForrestLevel()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.ForrestLevel);
    }

    public void LoadDessertLevel()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.DessertLevel);
    }

    public void LoadIceLevel()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.IceLevel);
    }

    public void LoadFantasyLevel()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

        SceneManager.LoadScene((int)SceneIndex.FantasyLevel);
    }

    public void LoadEnviroGamePlay()
    {
        if (GeneralAudioManager.Instance != null)
        {
            GeneralAudioManager.Instance.PlaySound(SoundType.Click);
        }

    //    SceneManager.LoadScene((int)SceneIndex.EnviroGamePlay);
        SceneFader.Instance.FadeInLoadFadeOut("EnviroGamePlay");
        
    }
}
