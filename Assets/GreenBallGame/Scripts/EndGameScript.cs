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
    [SerializeField] private AudioSource music;
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
            StartCoroutine(WaitEndGame());
        }
        if (_secondPlayerZoneTrigger.FirstPlayersPoints < _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            StartCoroutine(WaitEndGame());
        }
        if(_secondPlayerZoneTrigger.FirstPlayersPoints == _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            StartCoroutine(WaitEndGame());
        }

    }
    public IEnumerator WaitEndGame()
    {
        music.Stop();
        _rotatePlayers.PlayerOneRotationSpeed = 0;
        _rotatePlayers.PlayerTwoRotationSpeed = 0;
        greenBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        greenBall.GetComponent<Rigidbody2D>().simulated = false;
        blueButton.interactable = false;
        redButton.interactable = false;
        yield return new WaitForSeconds(1f);
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
