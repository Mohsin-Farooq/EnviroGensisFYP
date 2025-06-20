using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GetTreeID : MonoBehaviour
{
    [SerializeField] private int TreeID;
    
    public int GetMatchID() => TreeID;
}