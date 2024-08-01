
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform endTransform;
    public float Speed;
<<<<<<< HEAD
    public bool IsEnd;
=======

>>>>>>> 7a7a933a908c99bb3e8b7bb4f29ca83d2e33b166
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if (transform.position.x >= endTransform.position.x)
        {
            Speed = 0;
        }
    }
}
