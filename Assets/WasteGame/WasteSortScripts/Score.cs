using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI point;
    [SerializeField] private TextMeshProUGUI erro;
    [SerializeField] private TextMeshProUGUI life;

    private int pointCount;
    private int erroCount;
    private int lifeCount;

    public static Score Instance;



    public void StartScore()
    {
        point.text = (WasteGameManager.Instance.GetPointScoreValue()).ToString();
        erro.text = (WasteGameManager.Instance.GetErroScoreValue()).ToString();
        life.text = (WasteGameManager.Instance.GetLifeScoreValue()).ToString();

        pointCount = WasteGameManager.Instance.GetPointScoreValue();
        erroCount = WasteGameManager.Instance.GetErroScoreValue();
        lifeCount = WasteGameManager.Instance.GetLifeScoreValue();

        life.text = $"{lifeCount}";

        
    }

    private void Awake()
    {
        Instance = this;
    }
    public string GeTPointScore()
    {
        return point.text;
    }

    public void SetTPointScore()
    {
        pointCount++;
        point.text = $"{pointCount}";
    }

    public string GeTErroScore()
    {
        return erro.text;
    }

    public void SetTErroScore()
    {
        lifeCount--;
        erroCount++;
        erro.text = $"{erroCount}";

        if(lifeCount <= 0)
        {
            WasteGameManager.Instance.GameOver();
        }

        life.text = $"{lifeCount}";
    }

}
