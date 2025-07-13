using UnityEngine;

class FPSDisplay : MonoBehaviour
{
    public static FPSDisplay Instance;
    [Header("Display")]
    public TextAnchor fpsAnchor = TextAnchor.UpperLeft;
    public Color color = Color.red;
    public int fontSize = 3;
    float deltaTime = 0.0f;
    public bool SetCustomFrames = false;
  //  public int frameRate = 60;

    private void Awake()
    {
        // if (SetCustomFrames)
            // Application.targetFrameRate = frameRate;

        rect = new Rect(0, 0, Screen.width, Screen.height * 2 / 100);
        style = new GUIStyle();
        style.alignment = fpsAnchor;
        style.fontSize = (Screen.height * 2 / 100) * fontSize;
        style.normal.textColor = color;
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }


    Rect rect;
    GUIStyle style;
    float msec, fps;
    string format = "{0:0.0} ms ({1:0.} fps)";
    void OnGUI()
    {
        float msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;
        GUI.Label(rect, string.Format(format, msec, fps), style);
    }
}