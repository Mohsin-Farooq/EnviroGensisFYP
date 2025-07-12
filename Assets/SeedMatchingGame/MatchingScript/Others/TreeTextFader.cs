using UnityEngine;
using TMPro;
using System.Collections;

public class TreeTextFader : MonoBehaviour
{
    public static TreeTextFader Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void FadeOutAndDisable(TextMeshPro text)
    {
        StartCoroutine(FadeOut(text));
    }

    public void FadeInAndEnable(TextMeshPro text)
    {
        text.gameObject.SetActive(true);
        StartCoroutine(FadeIn(text));
    }

    private IEnumerator FadeOut(TextMeshPro text)
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1f, 0f, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        text.gameObject.SetActive(false);
    }

    private IEnumerator FadeIn(TextMeshPro text)
    {
        float duration = 1f;
        float elapsed = 0f;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);

        while (elapsed < duration)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(0f, 1f, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
    }
}