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
    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private bool endGame;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!endGame)
        {
            if(_playerOneColisions.PlayerOnePonts == 0)
            {
                endGame = true;
                _plOneMovement.speed = 0;
                _plTwoMovement.speed = 0;
                _borderMovement.Speed = 0;
                _cameraMovement.Speed = 0;
                _piranhaMovement.Speed = 0;
                playerTwoWinPc.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
            if(_playerTwoColisions.PlayerTwoPonts == 0)
            {
                endGame = true;
                _plOneMovement.speed = 0;
                _plTwoMovement.speed = 0;
                _borderMovement.Speed = 0;
                _cameraMovement.Speed = 0;
                _piranhaMovement.Speed = 0;
                playerOneWinPc.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
        }
    }
    public IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
