using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float Speed;
   
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}
