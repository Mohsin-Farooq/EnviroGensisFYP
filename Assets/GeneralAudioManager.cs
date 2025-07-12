using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SoundType
{
    Click,
    Match,
    Success,
    Fail,
    Correct,
    Incorrect,
    Countdown,
    // Add more as needed
}

[System.Serializable]
public struct SoundClip
{
    public SoundType soundType;
    public AudioClip clip;
}

public class GeneralAudioManager : MonoBehaviour
{
    public static GeneralAudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioSource> soundSources;

    [Header("UI Toggles")]
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle soundToggle;

    [Header("Sound Clips")]
    [SerializeField] private List<SoundClip> soundClips;

    private Dictionary<SoundType, AudioClip> soundClipMap;
    private bool isMusicOn;
    private bool isSoundOn;

    private string musicKey;
    private string soundKey;

    private void Awake()
    {
        Instance = this;

        // Build scene-specific keys
        string sceneName = SceneManager.GetActiveScene().name;
        musicKey = $"MusicOn_{sceneName}";
        soundKey = $"SoundOn_{sceneName}";

        // Build enum-to-clip dictionary
        soundClipMap = new Dictionary<SoundType, AudioClip>();
        foreach (var sc in soundClips)
        {
            if (!soundClipMap.ContainsKey(sc.soundType))
                soundClipMap.Add(sc.soundType, sc.clip);
        }
    }

    private void Start()
    {
        LoadAudioPreferences();
        ApplyToggleStates();
        SetupToggleListeners();
    }

    private void LoadAudioPreferences()
    {
        isMusicOn = PlayerPrefs.GetInt(musicKey, 1) == 1;
        isSoundOn = PlayerPrefs.GetInt(soundKey, 1) == 1;

        if (musicToggle != null)
            musicToggle.isOn = isMusicOn;

        if (soundToggle != null)
            soundToggle.isOn = isSoundOn;
    }

    private void ApplyToggleStates()
    {
        if (musicSource != null)
            musicSource.mute = !isMusicOn;

        foreach (var source in soundSources)
        {
            if (source != null)
                source.mute = !isSoundOn;
        }
    }

    private void SetupToggleListeners()
    {
        if (musicToggle != null)
            musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);

        if (soundToggle != null)
            soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
    }

    // You can also call these directly from the Toggle's OnValueChanged in the Inspector
    public void OnMusicToggleChanged(bool isOn)
    {
        isMusicOn = isOn;

        if (musicSource != null)
            musicSource.mute = !isOn;

        PlayerPrefs.SetInt(musicKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void OnSoundToggleChanged(bool isOn)
    {
        isSoundOn = isOn;

        foreach (var source in soundSources)
        {
            if (source != null)
                source.mute = !isOn;
        }

        PlayerPrefs.SetInt(soundKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Play a sound from the enum, using available sound sources only
    /// </summary>
    public void PlaySound(SoundType type)
    {
        if (!isSoundOn || !soundClipMap.ContainsKey(type))
            return;

        AudioClip clip = soundClipMap[type];
        if (clip == null) return;

        foreach (var source in soundSources)
        {
            if (source != null && !source.isPlaying)
            {
                source.clip = clip;
                source.Play();
                return;
            }
        }

        // All sources busy: skip playback (no dynamic source creation)
    }
}