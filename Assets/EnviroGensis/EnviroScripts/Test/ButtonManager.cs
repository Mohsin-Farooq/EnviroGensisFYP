using System.Collections;
using System.Collections.Generic;
using EnviroGenesis;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{  //game time 0.02s
//    float game_speed = TheGame.Get().GetGameTimeSpeedPerSec();
    public AudioClip audioSource;
    private float interval = 2f;
    [SerializeField] private List <GameObject> Buttons;
    private void Start()
    { 
        StartCoroutine(DecreaseRoutine());
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

    public void AttributeDecrease()
    {
        PlayerCharacterAttribute.instance.AddAttribute(AttributeType.Hunger,-20);
    }
    
    
    IEnumerator DecreaseRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            GetAttributeValue();
        }
    }
    
    

    public void GetAttributeValue()
    {
        float happiness = PlayerCharacterAttribute.instance.GetAttributeValue(AttributeType.Happiness);
        Buttons[1].SetActive(happiness < 30 ? true : false);

        float thirst = PlayerCharacterAttribute.instance.GetAttributeValue(AttributeType.Thirst);
        Buttons[3].SetActive(thirst < 30 ? true : false);

        float hunger = PlayerCharacterAttribute.instance.GetAttributeValue(AttributeType.Hunger);
        Buttons[2].SetActive(hunger < 30 ? true : false);

        float health = PlayerCharacterAttribute.instance.GetAttributeValue(AttributeType.Health);
        Buttons[0].SetActive(health < 30 ? true : false);
    }


    
    private IEnumerator NewRoutine()
    {
        BlackPanel.Get().Show();
        yield return new WaitForSeconds(1f);
        TheGame.Load();
    }
    
}


