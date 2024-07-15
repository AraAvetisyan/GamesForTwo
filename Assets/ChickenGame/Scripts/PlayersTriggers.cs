using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTriggers : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
   // [SerializeField] private GameObject playerTwoLose;
    [SerializeField] private PlayerMovement _playersMovement;
    [SerializeField] private CameraScript _cameraScript;
    //[SerializeField] private CameraScript _notTriggerScript;
    public bool EndGame;
    [SerializeField] private bool isSingle;
    private bool finish;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NotTrigger")
        {
            if(playerIndex == 1)
            {
                if (_playersMovement.IsMobile && !isSingle)
                {
                    playerTwoWinMobile.SetActive(true);
                }
                if(!_playersMovement.IsMobile || isSingle)
                {
                    playerTwoWinPC.SetActive(true);
                }
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
               // _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
            if(playerIndex == 2)
            {
                if (_playersMovement.IsMobile && !isSingle)
                {
                    playerOneWinMobile.SetActive(true);
                }
                if (!_playersMovement.IsMobile || isSingle)
                {
                    playerOneWinPC.SetActive(true);
                }
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
              //  _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
            //if (playerIndex == 2 && isSingle)
            //{
            //  //  playerTwoLose.SetActive(true);
            //    _playersMovement.Speed = 0;
            //    _cameraScript.Speed = 0;
            //    _notTriggerScript.Speed = 0;
            //    StartCoroutine(WaitToFinal());
            //    EndGame = true;
            //}
        }
        if(collision.gameObject.tag == "Trigger")
        {
            if(playerIndex == 1)
            {
                if (_playersMovement.IsMobile && !isSingle)
                {
                    playerOneWinMobile.SetActive(true);
                }
                if (!_playersMovement.IsMobile || isSingle)
                {
                    playerOneWinPC.SetActive(true);
                }
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
               // _notTriggerScript.Speed = 0;
                finish = true;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
            if (playerIndex == 2)
            {
                if (_playersMovement.IsMobile && !isSingle)
                {
                    playerTwoWinMobile.SetActive(true);
                }
                if (!_playersMovement.IsMobile || isSingle)
                {
                    playerTwoWinPC.SetActive(true);
                }
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
              //  _notTriggerScript.Speed = 0;
                finish = true;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }

            
        }
        if (collision.gameObject.tag == "ChickenGravity")
        {
            if (playerIndex == 1 && isSingle)
            {
                if (!finish)
                {
                    Debug.Log("AAAAA");
                    StartCoroutine(Single());
                }
            }
        }
    }
    public IEnumerator Single()
    {
        float timer = Random.Range(0, 0.001f);
        yield return new WaitForSeconds(timer);
        _playersMovement.PressedPlayerOneButton();
    }
    public IEnumerator WaitToFinal()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
