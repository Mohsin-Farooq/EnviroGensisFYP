using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis 
{
    
    [System.Serializable]
    public abstract class SData : ScriptableObject { }

    
    [System.Serializable]
    public abstract class IdData : SData { public string id; }

   

    [CreateAssetMenu(fileName = "SpawnData", menuName = "EnviroGenesis/SpawnData", order = 5)]
    public class SpawnData : IdData
    {
        public GameObject prefab;

        private static List<SpawnData> spawn_data = new List<SpawnData>();

        public static void Load(string folder = "")
        {
            spawn_data.Clear();
            spawn_data.AddRange(Resources.LoadAll<SpawnData>(folder));
        }

        public static SpawnData Get(string id)
        {
            foreach (SpawnData data in spawn_data)
            {
                if (data.id == id)
                    return data;
            }
            return null;
        }

        public static List<SpawnData> GetAll()
        {
            return spawn_data;
        }
    }
}


