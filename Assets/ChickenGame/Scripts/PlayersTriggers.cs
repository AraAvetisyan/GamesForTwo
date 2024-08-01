using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTriggers : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private PlayerMovement _playersMovement;
    [SerializeField] private CameraScript _cameraScript;
    [SerializeField] private ChickenResult _chickenResult;
    public bool EndGame;
    [SerializeField] private bool isSingle;
    private bool finish;
    private int winCounter;
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
                EndGame = true;
            }
            if(playerIndex == 2)
            {
                _chickenResult.countLose++;
                _chickenResult.plTwoLose = true;
               
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
              //  _notTriggerScript.Speed = 0;
                EndGame = true;
            }
        }
        if(collision.gameObject.tag == "Trigger")
        {
            if(playerIndex == 1)
            {
                if (winCounter == 0)
                {
                    _chickenResult.PlOneWin = true;
                    winCounter = 1;
                }
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
                finish = true;
                EndGame = true;
            }
            if (playerIndex == 2)
            {
                if (winCounter == 0)
                {
                    _chickenResult.PlTwoWin = true;
                    winCounter = 1;
                }
                _playersMovement.Speed = 0;
                _cameraScript.Speed = 0;
                finish = true;
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
   
}