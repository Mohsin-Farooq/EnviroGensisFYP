using UnityEngine;

public class Windowed : MonoBehaviour
{
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if(isFullScreen)
            Debug.Log("FullScreen");
        else
            Debug.Log("Windowed");

    }
}
