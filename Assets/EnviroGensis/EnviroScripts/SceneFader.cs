using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Fades in to black, loads the given scene, then fades out.
    /// Call this for full scene transition.
    /// </summary>
    public void FadeInLoadFadeOut(string sceneName)
    {
        StartCoroutine(FadeInLoadFadeOutRoutine(sceneName));
    }

    /// <summary>
    /// Fades in, performs optional action, then fades out.
    /// Does NOT load a scene.
    /// </summary>
    public void FadeInOut(Action onFadeMiddle = null)
    {
        StartCoroutine(FadeInOutRoutine(onFadeMiddle));
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float alpha = t / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1); // Full black
    }

    IEnumerator FadeInLoadFadeOutRoutine(string sceneName)
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
        yield return null;
        yield return StartCoroutine(FadeIn());
    }

    IEnumerator FadeInOutRoutine(Action onFadeMiddle)
    {
        yield return StartCoroutine(FadeOut());
        onFadeMiddle?.Invoke();
        yield return null;
        yield return StartCoroutine(FadeIn());
    }
}
