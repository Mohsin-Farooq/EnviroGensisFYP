using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

    

    public class SpawnFX : MonoBehaviour
    {

        public float lifetime = 5f; //In seconds

        void Start()
        {
            Destroy(gameObject, lifetime);
        }
    }

}
