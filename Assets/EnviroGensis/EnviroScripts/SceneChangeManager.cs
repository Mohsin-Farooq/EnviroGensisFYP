using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void LoadSplashScreen()
    {
        SceneManager.LoadScene((int)SceneIndex.SplashScreen);
    }

    public void LoadWasteSortMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.WasteSortMenu);
    }

    public void LoadWasteSortScene()
    {
        SceneManager.LoadScene((int)SceneIndex.WasteSortScene);
    }

    public void LoadQuizGame()
    {
        SceneManager.LoadScene((int)SceneIndex.QuizGame);
    }

    public void LoadSeedMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.SeedMenu);
    }

    public void LoadSeedGame()
    {
        SceneManager.LoadScene((int)SceneIndex.SeedGame);
    }

    public void LoadRiverMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.RiverMenu);
    }

    public void LoadForrestLevel()
    {
        SceneManager.LoadScene((int)SceneIndex.ForrestLevel);
    }

    public void LoadDessertLevel()
    {
        SceneManager.LoadScene((int)SceneIndex.DessertLevel);
    }

    public void LoadIceLevel()
    {
        SceneManager.LoadScene((int)SceneIndex.IceLevel);
    }

    public void LoadFantasyLevel()
    {
        SceneManager.LoadScene((int)SceneIndex.FantasyLevel);
    }

    public void LoadEnviroGamePlay()
    {
        SceneManager.LoadScene((int)SceneIndex.EnviroGamePlay);
    }
}
