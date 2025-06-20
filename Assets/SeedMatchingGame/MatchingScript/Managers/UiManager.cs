using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameOverPanel.SetActive(true);
    }

    public void DeactivateGameOverPanel()
    {
        GameOverPanel.SetActive(false);
    }
}