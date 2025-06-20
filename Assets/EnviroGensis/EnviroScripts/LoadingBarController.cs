using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBarController : MonoBehaviour
{
    public Slider loadingBar;  
    public float loadingTime = 10f;  
    private float elapsedTime = 0f;
    [SerializeField] private GameObject VideoPlayer;

    void Start()
    {
        loadingBar.value = 0f;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (elapsedTime < loadingTime)
        {
            elapsedTime += Time.deltaTime;
            loadingBar.value = Mathf.Clamp01(elapsedTime / loadingTime);
        }
        else
        {
            SceneManager.LoadScene((int)SceneIndex.EnviroGamePlay);
        } 
    }
}
