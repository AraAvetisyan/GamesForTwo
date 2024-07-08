using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriangaCameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
