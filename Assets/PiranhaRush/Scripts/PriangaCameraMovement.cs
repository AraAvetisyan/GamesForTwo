
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriangaCameraMovement : MonoBehaviour
{
    public float Speed;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
}
