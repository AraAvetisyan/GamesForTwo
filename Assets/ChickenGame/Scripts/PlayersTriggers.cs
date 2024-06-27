using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTriggers : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject playerOneWin, playerTwoWin;
    [SerializeField] private GameObject playerTwoLose;
    [SerializeField] private PlayerMovement _playersMovement;
    [SerializeField] private CameraScript _cameraScript;
    [SerializeField] private CameraScript _notTriggerScript;
    public bool EndGame;
    [SerializeField] private bool isSingle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NotTrigger")
        {
            if(playerIndex == 1 && !isSingle)
            {
                playerTwoWin.SetActive(true);
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
                _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
            if(playerIndex == 2 && !isSingle)
            {
                playerOneWin.SetActive(true);
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
                _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
            if (playerIndex == 2 && isSingle)
            {
                playerTwoLose.SetActive(true);
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
                _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
        }
        if(collision.gameObject.tag == "Trigger")
        {
            if(playerIndex == 1 && !isSingle)
            {
                playerOneWin.SetActive(true);
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
                _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
            if (playerIndex == 2)
            {
                playerTwoWin.SetActive(true);
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
                _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
        }
    }
    public IEnumerator WaitToFinal()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
