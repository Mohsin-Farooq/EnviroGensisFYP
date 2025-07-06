using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject parentOBJ;
    [SerializeField] private List<GameObject> residueList;
    [SerializeField] private float spawRate = 1f;
    [SerializeField] private GameObject spawnPoint;
    private WasteTypeListSO wasteTypeList;
    System.Random random = new System.Random();
    [SerializeField] private Canvas canvas;
    public static Spawner Instance;
    public float speed;
    private void Start()
    {
        Instance = this;
    }


    private void Awake()
    {
        wasteTypeList = Resources.Load<WasteTypeListSO>(typeof(WasteTypeListSO).Name);
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawRate, spawRate);
    }

    public void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (residueList == null || residueList.Count == 0) return;
        if (spawnPoint == null || parentOBJ == null) return;

        int i = random.Next(0, residueList.Count);
        GameObject residue = Instantiate(residueList[i], spawnPoint.transform.localPosition, Quaternion.identity);

        residue.transform.SetParent(parentOBJ.transform, false); // 'false' keeps local positioning/scaling
    }


    private void Update()
    {

        if (DragDrop.Instance != null)
        {
            DragDrop.Instance.speed = speed;
        }
    }

    //   public void DestroyOBJList()
    //   {
    //      Destroy(parentOBJ);
    //  }
}
