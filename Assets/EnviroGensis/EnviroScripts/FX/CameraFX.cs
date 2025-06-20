using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

    public class CameraFX : MonoBehaviour
    {
        
        void Update()
        {
            transform.position = TheCamera.Get().GetTargetPos();
            transform.rotation = Quaternion.LookRotation(TheCamera.Get().GetFacingFront(), Vector3.up);
        }
    }

}
