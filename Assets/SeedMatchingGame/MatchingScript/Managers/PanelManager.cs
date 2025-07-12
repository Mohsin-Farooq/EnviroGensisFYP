using UnityEngine;

namespace SeedMatchingGame
{
    public class PanelManager : MonoBehaviour
    {
  

        public void OpenPanel(GameObject panel)
        {
            if(panel != null)
            {
                Time.timeScale = 0f;
                panel.SetActive(true);
            }
        }

        public void ClosePanel(GameObject panel)
        {
            if(panel != null)
            {
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
        }

    }
}
