
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform endTransform;
    public float Speed;
    public bool IsEnd;
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if (transform.position.x >= endTransform.position.x)
        {
            IsEnd = true;
            Speed = 0;
        }
    }
}
