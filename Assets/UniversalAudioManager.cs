using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UniversalAudioManager : MonoBehaviour
{
    public static UniversalAudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource soundSource;

    [Header("Music Clips")]
    public List<NamedAudioClip> musicClips;

    [Header("Sound Clips")]
    public List<NamedAudioClip> soundClips;

    [Header("UI Toggles")]
    public Toggle musicToggle;
    public Toggle soundToggle;

    private Dictionary<string, AudioClip> musicDict;
    private Dictionary<string, AudioClip> soundDict;

    private string MUSIC_PREF;
    private string SOUND_PREF;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        // Build audio dictionaries
        musicDict = new Dictionary<string, AudioClip>();
        soundDict = new Dictionary<string, AudioClip>();

        foreach (var clip in musicClips)
            musicDict[clip.name] = clip.clip;

        foreach (var clip in soundClips)
            soundDict[clip.name] = clip.clip;
    }

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        MUSIC_PREF = sceneName + "_MusicEnabled";
        SOUND_PREF = sceneName + "_SoundEnabled";

        bool musicEnabled = PlayerPrefs.GetInt(MUSIC_PREF, 1) == 1;
        bool soundEnabled = PlayerPrefs.GetInt(SOUND_PREF, 1) == 1;

        if (musicToggle != null)
        {
            musicToggle.isOn = musicEnabled;
            musicToggle.onValueChanged.AddListener(ToggleMusic);
        }

        if (soundToggle != null)
        {
            soundToggle.isOn = soundEnabled;
            soundToggle.onValueChanged.AddListener(ToggleSound);
        }

        musicSource.mute = !musicEnabled;
        soundSource.mute = !soundEnabled;
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt(MUSIC_PREF, isOn ? 1 : 0);
    }

    public void ToggleSound(bool isOn)
    {
        soundSource.mute = !isOn;
        PlayerPrefs.SetInt(SOUND_PREF, isOn ? 1 : 0);
    }

    public void PlayMusicByName(string name, bool loop = true)
    {
        if (musicDict.TryGetValue(name, out var clip) && musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }
    }

    public void PlaySoundByName(string name)
    {
        if (soundDict.TryGetValue(name, out var clip) && soundSource != null)
        {
            soundSource.PlayOneShot(clip);
        }
    }
}

[System.Serializable]
public class NamedAudioClip
{
    public string name;
    public AudioClip clip;
}
