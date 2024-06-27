using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    [SerializeField] private GreenBallGameUIController _greenBallGameUIController;
    [SerializeField] private int playerNumber;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerNumber == 1 && _greenBallGameUIController.BlueBallActive == true)
            {
                _greenBallGameUIController.BlueBallActive = false;
                StartCoroutine(_greenBallGameUIController.SinglePlayer());
            }
            if (playerNumber == 2 && _greenBallGameUIController.RedBallActive == true)
            {
                _greenBallGameUIController.RedBallActive = false;
            }
        }
    }
}
