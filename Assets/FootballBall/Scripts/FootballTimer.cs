using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FootballTimer : MonoBehaviour
{
    private int seconds = 29;
    private int minutes = 1;
    private int allTime = 90;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC, drawPanel;

    [SerializeField] private FootballPlayerTwoRun _playersRun;

    [SerializeField] private GameObject finalPanel;
    [SerializeField] private FootballBallTriggers _footballBallTriggers;
    [SerializeField] private Rigidbody2D ballRb, plOneRb, plTwoRb;
    [SerializeField] private Button plOneButton, plTwoButton;
    public bool GameEnds;
    [SerializeField] private BoxCollider2D enemyBox;
    public bool playerOneWinBool, playerTwoWinBool, drawBool;
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject end;

    private void Start()
    {

        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        if (seconds < 0)
        {
            seconds = 0;
        }
        if (seconds >= 10)
        {
            timerText.text = minutes.ToString() + ":" + seconds.ToString();
        }
        else
        {
            timerText.text = minutes.ToString() + ":0" + seconds.ToString();
        }

        allTime--;
        seconds--;
        if (allTime > 0)
        {
            StartCoroutine(Timer());
        }
        if (seconds == 0 && minutes == 1)
        {
            minutes--;
            seconds = 59;
        }
        if (allTime <= 0)
        {
            if (_footballBallTriggers.PlayerOnePoints > _footballBallTriggers.PlayerTwoPoints)
            {
                playerOneWinBool = true;
                StartCoroutine(WaitToFinish());
            }
            if(_footballBallTriggers.PlayerOnePoints < _footballBallTriggers.PlayerTwoPoints)
            {
                playerTwoWinBool = true;
                StartCoroutine(WaitToFinish());
            }
            if(_footballBallTriggers.PlayerOnePoints == _footballBallTriggers.PlayerTwoPoints)
            {
                drawBool = true;
                StartCoroutine(WaitToFinish());
            }
        }
    }

    private void Update()
    {
        if (_footballBallTriggers.PlayerOnePoints >= 3 || _footballBallTriggers.PlayerTwoPoints >= 3)
        {
            GameEnds = true;
            plOneRb.velocity = Vector2.zero;
            plTwoRb.velocity = Vector2.zero;
            ballRb.velocity = Vector2.zero;
            enemyBox.enabled = false;
            if (_footballBallTriggers.PlayerOnePoints > _footballBallTriggers.PlayerTwoPoints) // blue player Win
            {

                playerOneWinBool = true;
                StartCoroutine(WaitToFinish());
            }
            if (_footballBallTriggers.PlayerOnePoints < _footballBallTriggers.PlayerTwoPoints) //red player win
            {

                playerTwoWinBool = true;
                StartCoroutine(WaitToFinish());
            }
            
        }
    }

    public IEnumerator WaitToFinish()
    {
        music.Stop();
        plOneButton.interactable = false;
        plTwoButton.interactable = false;

        yield return new WaitForSeconds(1f);
        end.SetActive(true);
        finalPanel.SetActive(true);
        if (playerOneWinBool)
        {
            playerOneWinPC.SetActive(true);
        }
        if (playerTwoWinBool)
        {
            playerTwoWinPC.SetActive(true);
        }
        if (drawBool)
        {
            drawPanel.SetActive(true);
        }
    }
}
