using UnityEngine;

namespace SeedMatchingGame
{
    public class PanelManager : MonoBehaviour
    {
  

        public void OpenPanel(GameObject panel)
        {
            if (GeneralAudioManager.Instance != null)
            {
                GeneralAudioManager.Instance.PlaySound(SoundType.Click);
            }
            if (panel != null)
            {
                Time.timeScale = 0f;
                panel.SetActive(true);
            }
        }

        public void ClosePanel(GameObject panel)
        {
            if (GeneralAudioManager.Instance != null)
            {
                GeneralAudioManager.Instance.PlaySound(SoundType.Click);
            }
            if (panel != null)
            {
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
        }

    }
}
