// using System.Collections.Generic;
// using UnityEngine;
//
// public class GenricAudioManager : MonoBehaviour
// {
//     public static GenricAudioManager instance;
//     
//     [Header("Audio Sources")]
//     public AudioSource musicSource;
//     public AudioSource soundSource;
//
//     [Header("Music Clips")]
//     public List<NamedAudioClip> musicClips;
//
//     [Header("Sound Clips")]
//     public List<NamedAudioClip> soundClips;
//
//     private Dictionary<string, AudioClip> musicDict;
//     private Dictionary<string, AudioClip> soundDict;
//
//     private string sceneName;
//     private string MUSIC_PREF;
//     private string SOUND_PREF;
//
//     private void Awake()
//     {
//         if (instance == null) instance = this;
//         else Destroy(gameObject);
//
//         // Build dictionaries
//         musicDict = new Dictionary<string, AudioClip>();
//         soundDict = new Dictionary<string, AudioClip>();
//
//         foreach (var clip in musicClips)
//             musicDict[clip.name] = clip.clip;
//
//         foreach (var clip in soundClips)
//             soundDict[clip.name] = clip.clip;
//     }
//
//     private void Start()
//     {
//         sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
//         MUSIC_PREF = sceneName + "_MusicEnabled";
//         SOUND_PREF = sceneName + "_SoundEnabled";
//
//         bool musicEnabled = PlayerPrefs.GetInt(MUSIC_PREF, 1) == 1;
//         bool soundEnabled = PlayerPrefs.GetInt(SOUND_PREF, 1) == 1;
//
//         if (musicSource != null) musicSource.mute = !musicEnabled;
//         if (soundSource != null) soundSource.mute = !soundEnabled;
//     }
//
//     public void PlayMusicByName(string name, bool loop = true)
//     {
//         if (!PlayerPrefs.HasKey(MUSIC_PREF) || PlayerPrefs.GetInt(MUSIC_PREF) == 1)
//         {
//             if (musicDict.TryGetValue(name, out var clip) && musicSource != null)
//             {
//                 musicSource.clip = clip;
//                 musicSource.loop = loop;
//                 musicSource.Play();
//             }
//         }
//     }
//
//     public void PlaySoundByName(string name)
//     {
//         if (!PlayerPrefs.HasKey(SOUND_PREF) || PlayerPrefs.GetInt(SOUND_PREF) == 1)
//         {
//             if (soundDict.TryGetValue(name, out var clip) && soundSource != null)
//             {
//                 soundSource.PlayOneShot(clip);
//             }
//         }
//     }
// }
// [System.Serializable]
// public class NamedAudioClip
// {
//     public string name;
//     public AudioClip clip;
// }