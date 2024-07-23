using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayers : MonoBehaviour
{

    [SerializeField] private GameObject playerOne, playerTwo;
    public float PlayerOneRotationSpeed, PlayerTwoRotationSpeed;
   
    void Update()
    {
        
        playerOne.transform.Rotate(0, 0, PlayerOneRotationSpeed * Time.deltaTime);

        playerTwo.transform.Rotate(0, 0, -PlayerTwoRotationSpeed * Time.deltaTime);
        
    }
}
