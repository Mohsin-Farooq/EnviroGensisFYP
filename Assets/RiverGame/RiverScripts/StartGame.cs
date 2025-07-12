using EnviroGenesis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	
	public LevelsCntrl levelNum;
	public void lLevel()
    {
        int level = levelNum.count;

        switch (level)
        {
            case 0:
                SceneManager.LoadScene((int)SceneIndex.ForrestLevel);
                break;
            case 1:
                SceneManager.LoadScene((int)SceneIndex.DessertLevel);
                break;
            case 2:
                SceneManager.LoadScene((int)SceneIndex.IceLevel);
                break;
            case 3:
                SceneManager.LoadScene((int)SceneIndex.FantasyLevel);
                break;
        }
			
    }

    public void ExitGame()
    {
        SceneManager.LoadScene((int)SceneIndex.EnviroGamePlay);
       
    }
}
