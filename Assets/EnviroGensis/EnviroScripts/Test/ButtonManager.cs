using System.Collections;
using EnviroGenesis;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{  //game time 0.02s
//    float game_speed = TheGame.Get().GetGameTimeSpeedPerSec();
    public AudioClip audioSource;

    private void Start()
    {
      //  TheAudio.Get().PlayMusic("ButtonManager", audioSource, 1,true);
      TheGame.Get().Save();
    }

    public void WaterCleanGame()
    {
    
        TheGame.Get().Save();
       SceneFader.Instance.FadeInLoadFadeOut("Menu");
    }
    
    public void WasteSortGame()
    {
        TheGame.Get().Save();
        SceneFader.Instance.FadeInLoadFadeOut("WasteSortMenu");
    }
    public void QuizGame()
    {
        TheGame.Get().Save();
        SceneFader.Instance.FadeInLoadFadeOut("QuizGame");
    }
    public void SeedMatchingGame()
    {
        TheGame.Get().Save();
        SceneFader.Instance.FadeInLoadFadeOut("SeedMatchingMenu");
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

