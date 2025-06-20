using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pairs : MonoBehaviour
{
    TMP_Text pairsCount;
    int previousPairsFound;  // Store the previous pairs found count
    GameObject gameController;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        pairsCount = GetComponent<TMP_Text>();
        gameController = GameObject.Find("GameController");
        previousPairsFound = GameController.pairsFound;  // Initialize previous pairs count
    }

    // Update is called once per frame
    void Update()
    {
        pairsCount.text = GameController.pairsFound.ToString() + "/" + GameController.size.ToString();

        // Check if pairsFound has changed
        if (previousPairsFound < GameController.pairsFound)
        {
            // Trigger rotation animation
            anim.SetBool("rotate", true);

            // Start the time delay coroutine to stop the rotation
            StartCoroutine(TimeDelay());
        }

        // Update the previousPairsFound count
        previousPairsFound = GameController.pairsFound;
    }

    public void SetRotationFalse()
    {
        anim.SetBool("rotate", false);
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("rotate", false);
    }
}
