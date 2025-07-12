using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels;
    private int currentLevel = 0;
    private GameObject levelToActivat;

    public void ActiveNewLevel()
    {
        if (currentLevel < levels.Count - 1)
        {
            currentLevel++;
            levelToActivat = levels[currentLevel];
            EnablingSeeds(levelToActivat);
        }
        else
        {
            currentLevel = -1;
            levelToActivat = levels[currentLevel + 1];
            EnablingSeeds(levelToActivat);
        }
    }

    public void DeActivatePrevLevel()
    {
        if (currentLevel == -1)
        {
            levels[(levels.Count) - 1].SetActive(false);
            UiManager.instance.DeactivateGameOverPanel();
            currentLevel = 0;
        }

        else if (currentLevel <= levels.Count - 1)
        {
            levels[currentLevel - 1].SetActive(false);
            UiManager.instance.DeactivateGameOverPanel();
        }
    }

    public void EnablingSeeds(GameObject levelToActivate)
    {
        levelToActivate.SetActive(true);
        
        SeedBehaviour[] seeds = levelToActivate.GetComponentsInChildren<SeedBehaviour>(true);
        foreach (var seed in seeds)
        {
            seed.enabled = true;
            seed.ResetSeedState();
        }
        
        GetTreeID[] trees = levelToActivate.GetComponentsInChildren<GetTreeID>(true);
        foreach (var tree in trees)
        {
            var label = tree.GetTreeName();
            if (label != null)
            {
                 label.gameObject.SetActive(true);       
                 label.alpha = 1f;                        
                TreeTextFader.Instance.FadeOutAndDisable(label);
            }
        }
    }
}