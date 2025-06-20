using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedInputManager : MonoBehaviour
{

    public delegate void OnSeedClick(Vector3 WorldPostion);
    public static event OnSeedClick OnSeedClickDown;
    public static event OnSeedClick OnSeedDrag;
    public static event OnSeedClick OnSeedClickUp;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnSeedClickDown?.Invoke(GetMouseWorldPosition());
        }

        if (Input.GetMouseButton(0))
        {
            OnSeedDrag?.Invoke(GetMouseWorldPosition());
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnSeedClickUp?.Invoke(GetMouseWorldPosition());
        }
    }
    
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
