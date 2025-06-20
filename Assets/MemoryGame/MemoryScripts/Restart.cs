using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Again()
    {
        //gameController.GetComponent<GameController>().Start();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("REstart");
        GameController.pairsFound = 0;
    }

    public void SuccessRestart()
    {
        //gameController.GetComponent<GameController>().Start();
        SceneManager.LoadScene((int)SceneIndex.MemorySuccess);
        print("REstart");
    }

   
}
