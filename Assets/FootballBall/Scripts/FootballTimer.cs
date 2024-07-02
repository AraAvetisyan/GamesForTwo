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

    [SerializeField] private GameObject playerOneDrawMobile, playerTwoDrawMobile;
    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;  

    [SerializeField] private GameObject playerOneDrawPC, playerTwoDrawPC;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;

    [SerializeField] private PlayersRun _playersRun;

    [SerializeField] private GameObject finalPanel;
    [SerializeField] private FootballBallTriggers _footballBallTriggers;
    [SerializeField] private Rigidbody2D ballRb,plOneRb,plTwoRb;
    [SerializeField] private Button plOneButton, plTwoButton;
    public bool GameEnds;
    [SerializeField] private BoxCollider2D enemyBox;
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
        if (allTime == 0)
        {
            GameEnds = true;
            plOneRb.velocity = Vector2.zero;
            plTwoRb.velocity = Vector2.zero;
            ballRb.velocity = Vector2.zero;
            enemyBox.enabled = false;
            if (_footballBallTriggers.PlayerOnePoints > _footballBallTriggers.PlayerTwoPoints)
            {
                if (_playersRun.IsMobile && !_playersRun.IsSingle)
                {
                    playerOneWinMobile.SetActive(true);
                }
                if (!_playersRun.IsMobile || _playersRun.IsSingle)
                {
                    playerOneWinPC.SetActive(true);
                }
                StartCoroutine(WaitToFinish());
            }
            if (_footballBallTriggers.PlayerOnePoints < _footballBallTriggers.PlayerTwoPoints)
            {
                if (_playersRun.IsMobile && !_playersRun.IsSingle)
                {
                    playerTwoWinMobile.SetActive(true);
                }
                if (!_playersRun.IsMobile || _playersRun.IsSingle)
                {
                    playerTwoWinPC.SetActive(true);
                }

                StartCoroutine(WaitToFinish());
            }
            if (_footballBallTriggers.PlayerTwoPoints == _footballBallTriggers.PlayerOnePoints)
            {
                if (_playersRun.IsMobile && !_playersRun.IsSingle)
                {
                    playerOneDrawMobile.SetActive(true);
                    playerTwoDrawMobile.SetActive(true);
                }
                if (!_playersRun.IsMobile || _playersRun.IsSingle)
                {
                    playerOneDrawPC.SetActive(true);
                    playerTwoDrawPC.SetActive(true);
                }
                StartCoroutine(WaitToFinish());
            }

        }

    }
    public IEnumerator WaitToFinish()
    {
        plOneButton.interactable = false;
        plTwoButton.interactable = false;

        yield return new WaitForSeconds(1.5f);

        finalPanel.SetActive(true);
    }
}
