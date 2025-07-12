using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class GetTreeID : MonoBehaviour
{
    [SerializeField] private int TreeID;
    [SerializeField] private TextMeshPro TreeName;
    
    public int GetMatchID() => TreeID;
    public TextMeshPro GetTreeName() => TreeName;
}