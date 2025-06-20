using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsCntrl : MonoBehaviour {
	
	
	public GameObject butLeft;
	public GameObject butRight;
	public GameObject[] Levels;
	public int count = 0;


	public Text record;
	public Text coins;



	void Start()
	{
		record.text = PlayerPrefs.GetInt ("Score").ToString();
        coins.text = PlayerPrefs.GetInt("Gold").ToString();  
	}



	public void right()
	{
		if (count < Levels.Length-1) {
			Levels [count].SetActive (false);
			count++;
      
			Levels [count].SetActive (true);
		}

		if (count != 0)
			butLeft.SetActive (true);
		if (count == Levels.Length - 1)
			butRight.SetActive (false);

            
     
			
	}

	public void left() {
		if (count > 0) {
			Levels [count].SetActive (false);
			count--;
         
			Levels [count].SetActive (true);
		}

		if (count == 0)
			butLeft.SetActive (false);
		if (count != Levels.Length - 1)
			butRight.SetActive (true);

       
      
	}
}
