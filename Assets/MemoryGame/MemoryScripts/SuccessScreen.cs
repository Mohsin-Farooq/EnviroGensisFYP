using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessScreen : MonoBehaviour
{
    GameObject audioControl;
    void Start()
    {
        audioControl = GameObject.Find("AudioControl");
        audioControl.GetComponent<AudioControl>().SuccessSound();
    }

}
