
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int size = 8;
    System.Random rnd = new System.Random();
    List<int> frontFaces = new List<int>();
    public int[] visibleFrontFace = { -1, -2 };
    GameObject card;
    public bool twoCardsUp;
    GameObject canvas, audioControl, bg4x4, videoBG4, videoBG6, bg6x6;
    public bool[] match;
    public static int pairsFound = 0;
    public SpriteRenderer firstCard = null, secondCard = null;

    GameObject firstCardObject = null;
    GameObject secondCardObject = null;
    // Start is called before the first frame update
    public int Visible1()
    {
        return visibleFrontFace[0];
    }
    public void Start()
    {
        videoBG4 = GameObject.Find("VideoBG4");
        videoBG6 = GameObject.Find("VideoBG6");
        videoBG4.SetActive(false);
        videoBG6.SetActive(false);
        bg4x4 = GameObject.Find("BG4x4");
        bg6x6 = GameObject.Find("BG6x6");
        if (size == 8)
        {
            bg4x4.SetActive(true);
            videoBG4.SetActive(true);
            bg6x6.SetActive(false);
        }
        else
        {
            bg4x4.SetActive(false);
            videoBG6.SetActive(true);
            bg6x6.SetActive(true);
        }
        match = new bool[size];
        card = GameObject.Find("Card");
        canvas = GameObject.Find("CardContainer");
        PopulateFrontFaces();
        Spawner();
        for (int i = 0; i < size; i++)
            match[i] = false;
        audioControl = GameObject.Find("AudioControl");
        audioControl.GetComponent<AudioControl>().GameStart();

    }

    void PopulateFrontFaces()
    {
        for (int i = 0; i < size * 2; i++)
        {
            frontFaces.Add(i % size);
        }
    }

    int RandomNo()
    {
        int random = frontFaces[rnd.Next(0, frontFaces.Count)];
        frontFaces.Remove(random);
        //for(int i=0; i< frontFaces.Count; i++)
        //{
        //    Debug.Log(frontFaces[i]);

        //}
        return random;
    }

    private void Spawner()
    {
        int sideSize;
        float x_pos, y_pos, x_pos1, gap;
        Vector3 scale;

        if (size == 8)
        {
            sideSize = 4;
            x_pos = card.transform.position.x;
            x_pos = -6.6f;
            x_pos1 = x_pos;
            y_pos = card.transform.position.y;
            y_pos = 3f;
            gap = 2f;
            scale = new Vector3(1.3f, 1.3f, 1f);
        }
        else
        {
            sideSize = 6;
            x_pos = -6.6f;
            x_pos1 = x_pos;
            y_pos = 3.8f;
            gap = 1.5f;
            scale = new Vector3(1f, 1f, 1.16f);
        }


        int randomNo = rnd.Next(0, (frontFaces.Count));
        for (int i = 0; i < sideSize; i++)
        {
            for (int j = 0; j < sideSize; j++)
            {
                int r = RandomNo();

                GameObject new_card = Instantiate(card, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                CardFlip cf = new_card.GetComponent<CardFlip>();
                cf.frontIndex = r;
                cf.transform.localScale = scale;
                cf.transform.SetParent(canvas.transform);
               

                x_pos = x_pos + gap;
            }
            x_pos = x_pos1;
            y_pos = y_pos - gap;
        }
        Destroy(card);
    }

    public bool TwoCardsUp()
    {
        if (visibleFrontFace[0] >= 0 && visibleFrontFace[1] >= 0)
            return true;
        return false;
    }


    public void AddFrontFace(int index, GameObject cardObject)
    {
        if (visibleFrontFace[0] == -1)
        {
            visibleFrontFace[0] = index;
            firstCardObject = cardObject;
        }
        else if (visibleFrontFace[1] == -2)
        {
            visibleFrontFace[1] = index;
            secondCardObject = cardObject;
        }
    }



   
    public void RemoveFrontFace(int index)
    {
        if (visibleFrontFace[0] == index)
            visibleFrontFace[0] = -1;

        else if (visibleFrontFace[1] == index)
            visibleFrontFace[1] = -2;
    }

    public void RemoveAllFrontFace()
    {

        visibleFrontFace[0] = -1;


        visibleFrontFace[1] = -2;
    }



    public bool IsMatch()
    {
        if (visibleFrontFace[0] == visibleFrontFace[1])
        {

          //  Disable the cards so they can no longer be interacted with
            firstCardObject.SetActive(false);
            secondCardObject.SetActive(false);


           // Reset visibleFrontFace so no cards are currently flipped
            visibleFrontFace[0] = -1;
            visibleFrontFace[1] = -2;

            //Reset the card GameObject references
           firstCardObject = null;
            secondCardObject = null;

            //Increment pairsFound and play the right sound
           pairsFound++;
            audioControl.GetComponent<AudioControl>().RightSound();
            StartCoroutine(TimeDelay());


            return true;
        }

        return false;
    }



    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);


    }



}
