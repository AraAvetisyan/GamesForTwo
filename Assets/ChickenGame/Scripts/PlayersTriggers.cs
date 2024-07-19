using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTriggers : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private PlayerMovement _playersMovement;
    [SerializeField] private CameraScript _cameraScript;
    [SerializeField] private ChickenResult _chickenResult;
    public bool EndGame;
    [SerializeField] private bool isSingle;
    private bool finish;
    
    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NotTrigger")
        {
            if(playerIndex == 1)
            {
                _chickenResult.countLose++;
                _chickenResult.plOneLose = true;
               
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
               // _notTriggerScript.Speed = 0;
                StartCoroutine(WaitToFinal());
                EndGame = true;
            }
            if(playerIndex == 2)
            {
                _chickenResult.countLose++;
                _chickenResult.plTwoLose = true;
               
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
                    _chickenResult.playerOneWinMobile.SetActive(true);
                }
                if (!_playersMovement.IsMobile || isSingle)
                {
                    _chickenResult.playerOneWinPC.SetActive(true);
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
                    _chickenResult.playerTwoWinMobile.SetActive(true);
                }
                if (!_playersMovement.IsMobile || isSingle)
                {
                    _chickenResult.playerTwoWinPC.SetActive(true);
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
