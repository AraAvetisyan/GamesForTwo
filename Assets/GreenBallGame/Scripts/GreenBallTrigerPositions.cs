using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallTrigerPositions : MonoBehaviour
{
    [SerializeField] private Transform firstPosition, secondPosition;
    [SerializeField] private GameObject firstTrigger, secondTrigger;
    
    void Update()
    {
        firstTrigger.transform.position = firstPosition.position;
        secondTrigger.transform.position = secondPosition.position;

    }
}
