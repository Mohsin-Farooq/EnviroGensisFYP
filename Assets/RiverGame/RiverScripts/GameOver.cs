using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public Transform target;
	public Transform boat;
	public Rigidbody rBody;
	public GameObject psSmokeOn;
	public GameObject psExplosionOn;
	public GameObject psVolni_Of;
    public GameObject psVolni2_Of; 

	public bool gameOver;
	public GameObject panelGameOver;
	public PauseMenu pauseM;
	public GameObject[] objects; 

	public AudioSource audio;
	public AudioSource soundBoat;
	public GameObject fireSound;

	public BoatController BCntrlOf;
	public GameObject pauseBtn;

	public GameObject[] uiTexts;

	public ScoreManager scMngr;
	bool proScore = true;


	void Start () {
		gameOver = false;
	}
	

	void Update () {
		if (gameOver) {

			pauseBtn.SetActive (false);

			soundBoat.mute = true;
			audio.mute = true;
			fireSound.SetActive(true);

			BCntrlOf.enabled = false;
			rBody.isKinematic = false;
			rBody.useGravity = true;

			if(boat.position.y < -1.38f)
				psSmokeOn.SetActive (true);

            psVolni_Of.SetActive(false); 
            psVolni2_Of.SetActive(false);
			psExplosionOn.SetActive (true); 


			for (int i = 0; i < objects.Length; i++)
				objects [i].SetActive (false);

			
			if (boat.position.y < -1.38f) {
				
				if (proScore) {
					scMngr.ResultScore ();
					proScore = false;
				}

				for (int i = 0; i < uiTexts.Length; i++)
					uiTexts [i].SetActive (false);
				
				panelGameOver.SetActive (true);
				pauseM.pause = true;

			}
		}
	}

}
