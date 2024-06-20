using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayers : MonoBehaviour
{

    [SerializeField] private bool playerOne, playerTwo;
    [SerializeField] private float rotationSpeed;
   
    void Update()
    {
        if (playerOne)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (playerTwo)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}
