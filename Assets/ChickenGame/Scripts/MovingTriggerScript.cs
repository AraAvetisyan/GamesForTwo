using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTriggerScript : MonoBehaviour
{
    [SerializeField] private CameraScript _cameraScript;
    
    void Update()
    {
        transform.Translate(Vector3.right * _cameraScript.Speed * Time.deltaTime);
    }
}
