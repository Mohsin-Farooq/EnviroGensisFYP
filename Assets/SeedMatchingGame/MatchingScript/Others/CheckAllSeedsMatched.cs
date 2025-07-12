using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllSeedsMatched : MonoBehaviour
{
    public static CheckAllSeedsMatched instance;

    private void Awake()
    {
        instance = this;
    }

    public void AllSeedsMatched()
    {
       
        if (SeedBehaviour.ActiveSeedCount == 0)
        {    
           Invoke(nameof(ShowPannel), 0.5f);
        }
    }

    private void ShowPannel()
    {
        UiManager.instance.ActivateGameOverPanel();
    }
}