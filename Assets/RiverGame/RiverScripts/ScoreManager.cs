using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text FishCount;
    public Text Coins;

    public Text score;
    public Text bestScore;

    public Text personalMoney; 
    public Text finalCoins;

    public GameObject congr;
    public GameObject textCongr1Obj;
    public Text textCongr2;
    public GameObject textCongr2Obj;

    public void ResultScore () {

        score.text = FishCount.text;
        bestScore.text = PlayerPrefs.GetInt ("Score").ToString();
        finalCoins.text = Coins.text;
        textCongr2.text = score.text;

        if (int.Parse(score.text) > PlayerPrefs.GetInt("Score"))
        {
            congr.SetActive(true);
            textCongr1Obj.SetActive(true);
            textCongr2Obj.SetActive(true);

            PlayerPrefs.SetInt ("Score", int.Parse (FishCount.text));
        }
        personalMoney.text = PlayerPrefs.GetInt ("Gold").ToString ();
        PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt("Gold") + int.Parse (Coins.text));
    }

}