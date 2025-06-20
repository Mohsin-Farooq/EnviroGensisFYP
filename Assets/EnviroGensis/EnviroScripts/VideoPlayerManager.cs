using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer VP;
    [SerializeField] private GameObject VideoCanvas;
    void Start()
    {
        VP.loopPointReached += OnvideoComplete;
    }

    private void OnvideoComplete(VideoPlayer videoPlayer)
    {
        VideoCanvas.SetActive(false);
        VP.gameObject.SetActive(false);
    }
}
