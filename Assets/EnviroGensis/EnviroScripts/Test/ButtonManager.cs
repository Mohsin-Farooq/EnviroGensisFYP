using System;
using System.Collections;
using System.Collections.Generic;
using EnviroGenesis;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{  //game time 0.02s
    float game_speed = TheGame.Get().GetGameTimeSpeedPerSec();
    public void AttributeIncrease()
    {
       PlayerCharacterAttribute.instance.AddAttribute(AttributeType.Happiness,20);
       TheGame.Get().Save();
       SceneFader.Instance.FadeInLoadFadeOut("Menu");
    }

//add this on any button for test prupose 
    public void AttributeDecrease()
    {
        PlayerCharacterAttribute.instance.AddAttribute(AttributeType.Happiness,-20);
    }
    
//cal this update or corotuine
    public void GetAttributeValue()
    {
        PlayerCharacterAttribute.instance.GetAttributeValue(AttributeType.Happiness);
        
    }
    
    private IEnumerator NewRoutine()
    {
        BlackPanel.Get().Show();
        yield return new WaitForSeconds(1f);
        TheGame.Load();
    }
    
}

