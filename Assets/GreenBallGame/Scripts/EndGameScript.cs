using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private GreenBallGameUIController _greenBallGameUIController;
    [SerializeField] private SecondPlayerZoneTrigger _secondPlayerZoneTrigger;
    [SerializeField] private FirstPlayerZoneTrigger _firstPlayerZoneTrigger;
    [SerializeField] private GameObject firstPlayerWinPC, secondPlayerWinPC, drawPC;
    [SerializeField] private GameObject finalPanel;
    public bool GameEnds;

    [SerializeField] private RotatePlayers _rotatePlayers;
    [SerializeField] private GameObject greenBall;
    [SerializeField] private Button blueButton, redButton;
    private void OnEnable()
    {
        TimerScript.GameEnds += EndGame;
    }
    private void OnDisable()
    {
        TimerScript.GameEnds -= EndGame;
    }
    public void EndGame(bool bb)
    {
        GameEnds = true;
        if (_secondPlayerZoneTrigger.FirstPlayersPoints > _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            //if (_greenBallGameUIController.IsMobile && !_greenBallGameUIController.IsSingle)
            //{
            //    firstPlayerWinMobile.SetActive(true);
            //}
            //if (_greenBallGameUIController.IsSingle || !_greenBallGameUIController.IsMobile)
            //{
            //    firstPlayerWinPC.SetActive(true);
            //}
            StartCoroutine(WaitEndGame());
        }
        if (_secondPlayerZoneTrigger.FirstPlayersPoints < _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            //if (_greenBallGameUIController.IsMobile && !_greenBallGameUIController.IsSingle)
            //{
            //    secondPlayerWinMobile.SetActive(true);
            //}
            //if (_greenBallGameUIController.IsSingle || !_greenBallGameUIController.IsMobile)
            //{
            //    secondPlayerWinPC.SetActive(true);
            //}
            StartCoroutine(WaitEndGame());
        }
        if(_secondPlayerZoneTrigger.FirstPlayersPoints == _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            //if (_greenBallGameUIController.IsMobile && !_greenBallGameUIController.IsSingle)
            //{
            //    drawMobile.SetActive(true);
            //    drawMobile2.SetActive(true);
            //}
            //if (_greenBallGameUIController.IsSingle || !_greenBallGameUIController.IsMobile)
            //{
            //    drawPC.SetActive(true);
            //    drawPC2.SetActive(true);
            //}
            StartCoroutine(WaitEndGame());
        }

    }
    public IEnumerator WaitEndGame()
    {
        _rotatePlayers.PlayerOneRotationSpeed = 0;
        _rotatePlayers.PlayerTwoRotationSpeed = 0;
        greenBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        greenBall.GetComponent<Rigidbody2D>().simulated = false;
        blueButton.interactable = false;
        redButton.interactable = false;
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
        if (_secondPlayerZoneTrigger.FirstPlayersPoints > _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            firstPlayerWinPC.SetActive(true);
        }
        if (_secondPlayerZoneTrigger.FirstPlayersPoints < _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            secondPlayerWinPC.SetActive(true);
        }
        if (_secondPlayerZoneTrigger.FirstPlayersPoints == _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            drawPC.SetActive(true);
        }
    }
}
