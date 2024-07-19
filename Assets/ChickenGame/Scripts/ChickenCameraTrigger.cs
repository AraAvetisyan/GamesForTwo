using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCameraTrigger : MonoBehaviour
{
    [SerializeField] private CameraScript camerCameraScripts;
    [SerializeField] private PlayersTriggers triggerOne, triggerTwo;
    private bool insidePlOne;
    private bool insidePlTwo;

    private void Update()
    {

        if (insidePlOne || insidePlTwo)
        {
            if (!triggerOne.EndGame && !triggerTwo.EndGame)
            {
                camerCameraScripts.Speed = 6;
            }
        }
        if(!insidePlOne && !insidePlTwo)
        {
            if (!triggerOne.EndGame && !triggerTwo.EndGame)
            {
                camerCameraScripts.Speed = 4;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            insidePlOne = true;
        }
        if (collision.gameObject.tag == "PlayerTwo")
        {
            insidePlTwo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerOne")
        {
            insidePlOne = false;
        }
        if (collision.gameObject.tag == "PlayerTwo")
        {
            insidePlTwo = false;
        }
    }
}
