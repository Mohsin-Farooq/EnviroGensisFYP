using System;
using System.Collections;
using System.Collections.Generic;
using EnviroGenesis;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public void AttributeIncrease()
    {
       PlayerCharacterAttribute.instance.AddAttribute(AttributeType.Happiness,20);
       TheGame.Get().Save();
       SceneFader.Instance.FadeInLoadFadeOut("Menu");
    }
    
    private IEnumerator NewRoutine()
    {
        BlackPanel.Get().Show();
        yield return new WaitForSeconds(1f);
        TheGame.Load();
    }
    
}
