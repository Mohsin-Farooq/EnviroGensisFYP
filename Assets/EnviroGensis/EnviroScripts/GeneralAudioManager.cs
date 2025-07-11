using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralAudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundSource;
    public Toggle musicToggle;
    public Toggle soundToggle;

    private string sceneName;
    private string MUSIC_PREF;
    private string SOUND_PREF;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        MUSIC_PREF = sceneName + "_MusicEnabled";
        SOUND_PREF = sceneName + "_SoundEnabled";

        // Load preferences or default to true
        bool musicEnabled = PlayerPrefs.GetInt(MUSIC_PREF, 1) == 1;
        bool soundEnabled = PlayerPrefs.GetInt(SOUND_PREF, 1) == 1;

        // Set the toggles if assigned
        if (musicToggle != null) musicToggle.isOn = musicEnabled;
        if (soundToggle != null) soundToggle.isOn = soundEnabled;

        // Apply audio settings
        ToggleMusic(musicEnabled);
        ToggleSound(soundEnabled);
    }

    public void ToggleMusic(bool isOn)
    {
        if (musicSource != null)
        {
            musicSource.mute = !isOn;
        }
        PlayerPrefs.SetInt(MUSIC_PREF, isOn ? 1 : 0);
    }

    public void ToggleSound(bool isOn)
    {
        if (soundSource != null)
        {
            soundSource.mute = !isOn;
        }
        PlayerPrefs.SetInt(SOUND_PREF, isOn ? 1 : 0);
    }
}
