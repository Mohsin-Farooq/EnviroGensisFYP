using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{
    

    [ExecuteInEditMode]
    public class SpriteShadow : MonoBehaviour
    {
        void Start()
        {
            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().receiveShadows = true;
            }
        }
    }

}
