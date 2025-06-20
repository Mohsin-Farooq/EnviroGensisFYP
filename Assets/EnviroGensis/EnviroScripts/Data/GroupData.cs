using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

    [CreateAssetMenu(fileName = "GroupData", menuName = "EnviroGenesis/GroupData", order = 1)]
    public class GroupData : ScriptableObject
    {
        public string group_id;
        public string title;
        public Sprite icon;
    }

}