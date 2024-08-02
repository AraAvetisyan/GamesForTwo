using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    [SerializeField] private GreenBallGameUIController _greenBallGameUIController;
    [SerializeField] private int playerNumber;
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource activatorSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerNumber == 1 && _greenBallGameUIController.BlueBallActive == true)
            {
                activatorSound.Play();
                _greenBallGameUIController.BlueBallActive = false;
                if (isSingle)
                {
                    StartCoroutine(_greenBallGameUIController.SinglePlayer());
                }
            }
            if (playerNumber == 2 && _greenBallGameUIController.RedBallActive == true)
            {
                activatorSound.Play();
                _greenBallGameUIController.RedBallActive = false;
            }
        }
    }
}
