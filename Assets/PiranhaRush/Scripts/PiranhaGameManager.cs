using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaGameManager : MonoBehaviour
{
    [SerializeField] private PlayerOneColisions _playerOneColisions;
    [SerializeField] private PlayerTwoColisions _playerTwoColisions;
    [SerializeField] private PiranhaGamePlayerMovement _plOneMovement, _plTwoMovement;
    [SerializeField] private PriangaCameraMovement _cameraMovement, _piranhaMovement, _borderMovement;
    [SerializeField] private GameObject playerOneWinPc, playerTwoWinPc;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private bool endGame;
    private bool plOneWin, plTwoWin;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!endGame)
        {
            if(_playerOneColisions.PlayerOnePonts <= 0)
            {
                _playerOneColisions.PlayerOnePonts = 0;
                _plOneMovement.enabled = false;
                _playerTwoColisions.enabled = false;
                endGame = true;
                _plOneMovement.speed = 0;
                _plTwoMovement.speed = 0;
                _borderMovement.Speed = 0;
                _cameraMovement.Speed = 0;
                _piranhaMovement.Speed = 0;
               // playerTwoWinPc.SetActive(true);
                plTwoWin = true;
                StartCoroutine(WaitToFinish());
            }
            if(_playerTwoColisions.PlayerTwoPonts <= 0)
            {
                _playerTwoColisions.PlayerTwoPonts = 0;
                _plOneMovement.enabled = false;
                _playerTwoColisions.enabled = false;
                endGame = true;
                _plOneMovement.speed = 0;
                _plTwoMovement.speed = 0;
                _borderMovement.Speed = 0;
                _cameraMovement.Speed = 0;
                _piranhaMovement.Speed = 0;
               // playerOneWinPc.SetActive(true);
                plOneWin = true;
                StartCoroutine(WaitToFinish());
            }
        }
    }
    public IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1f);
        finalPanel.SetActive(true);
        if (plOneWin)
        {
            playerOneWinPc.SetActive(true);
        }
        if(plTwoWin)
        {
            playerTwoWinPc.SetActive(true);
        }
    }
}
