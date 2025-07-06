using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public bool pause = false;
	public bool soundOf = false;
	public GameObject PausePanel;
	public Button pauseBtn;
	public GameObject settingsPanel;
	private Scene scene;

	public Toggle togMusic;
	public Toggle togSound;

	private AudioSource audio;

	public GameOver gOver;

	void Start()
	{     
		if(!soundOf)
			AudioListener.volume = 1;
		
		scene = SceneManager.GetActiveScene ();
		audio = GameObject.Find ("Directional Light").GetComponent<AudioSource> ();

		if (PlayerPrefs.GetString ("Music") == "No")
			togMusic.isOn = false;
		if (PlayerPrefs.GetString ("Sound") == "No")
			togSound.isOn = false;

	}

	public void PauseM()
	{
			AudioListener.volume = 0;
			PausePanel.SetActive(true);
			Time.timeScale = 0.00001f;
			pause = true;
			pauseBtn.interactable = false;
			return;
	}

	public void ResumeBut()
	{
		if(!soundOf)
			AudioListener.volume = 1;


		PausePanel.SetActive(false);
		Time.timeScale = 1;
		pause = false;
        pauseBtn.interactable = true;
		return;
	}


	public void SettingBut()
	{
		PausePanel.SetActive (false);
		settingsPanel.SetActive (true);
	}

	public void RestartBut()
	{
		if(!soundOf)
			AudioListener.volume = 1;
		
		Time.timeScale = 1;
		SceneManager.LoadScene (scene.name);
	}

	public void MainMenuBtn()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ((int)SceneIndex.RiverMenu);
	}

	public void pauseGOver()
	{
		ResumeBut();
		gOver.gameOver = true;

	}


	public void MusicOnOf()
	{
		if (audio.mute == true) {
			audio.mute = false;
			PlayerPrefs.SetString ("Music", "Yes");
		} else {
			audio.mute = true;
			PlayerPrefs.SetString ("Music", "No");
		}
	}

	public void SoundOnOf()
	{
		if(!soundOf) {
			AudioListener.volume = 0;
			PlayerPrefs.SetString ("Sound", "No");
			soundOf = true;
			return;
	   }
		if (soundOf)  {
			AudioListener.volume = 1;
			PlayerPrefs.SetString ("Sound", "Yes");
			soundOf = false;
			return;
	   }
	
	}

	public void OkBut()
	{
		settingsPanel.SetActive (false);
		PausePanel.SetActive (true);
	}




}
