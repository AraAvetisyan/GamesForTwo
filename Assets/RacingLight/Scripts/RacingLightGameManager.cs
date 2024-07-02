
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingLightGameManager : MonoBehaviour
{
    private float playerOneTimer, playerTwoTimer;

    public int counter;
    [SerializeField] private TextMeshProUGUI playerOneTimerText, playerTwoTimerText;
    private int playerOneScore, playerTwoScore;
    [SerializeField] private TextMeshProUGUI playerOneScoreText, playerTwoScoreText;
    [SerializeField] RacingButtonsHold _playerOneRacingButtonsHold, _playerTwoRacingButtonsHold;
    [SerializeField] private FireLightsScript _fireLightsScript;
    private int playerOneCounter, playerTwoCounter;
    [SerializeField] private GameObject playerOneWin, playerTwoWin;
    [SerializeField] private GameObject finalPanel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_fireLightsScript.CanHoldOff)
        {
            playerOneCounter++;
            playerTwoCounter++;
            if (!_playerOneRacingButtonsHold.PlayerOneSoon && playerOneCounter == 1)
            {
                playerOneCounter++;
                StartCoroutine(UpdatePlOneTimer());
            }
            if (!_playerTwoRacingButtonsHold.PlayerTwoSoon && playerTwoCounter == 1)
            {
                playerTwoCounter++;
                StartCoroutine(UpdatePlTwoTimer());
            }
        }
        if(counter == 1)
        {
            if (_playerOneRacingButtonsHold.PlayerOneSoon)
            {
                _playerOneRacingButtonsHold.CantHold = true;
            }
            if (_playerTwoRacingButtonsHold.PlayerTwoSoon)
            {
                _playerTwoRacingButtonsHold.CantHold = true;
            }
        }
        if (counter == 2)
        {
            if (_playerOneRacingButtonsHold.PlayerOneOnTime)
            {
                playerOneTimerText.text = playerOneTimer.ToString("F2");
            }
            if (_playerOneRacingButtonsHold.PlayerOneSoon)
            {
                playerOneTimerText.text = "Failed";
            }
            if (_playerTwoRacingButtonsHold.PlayerTwoOnTime)
            {
                playerTwoTimerText.text = playerTwoTimer.ToString("F2");
            }
            if (_playerTwoRacingButtonsHold.PlayerTwoSoon)
            {
                playerTwoTimerText.text = "Failed";
            }

            if (_playerOneRacingButtonsHold.PlayerOneOnTime && _playerTwoRacingButtonsHold.PlayerTwoOnTime)
            {
                if (playerOneTimer < playerTwoTimer)
                {
                    playerOneScore++;
                    playerOneScoreText.text = playerOneScore.ToString();

                }
                if (playerOneTimer > playerTwoTimer)
                {
                    playerTwoScore++;
                    playerTwoScoreText.text = playerTwoScore.ToString();
                }
                counter = 3;
            }
            if (_playerOneRacingButtonsHold.PlayerOneOnTime && _playerTwoRacingButtonsHold.PlayerTwoSoon)
            {
                playerOneScore++;
                playerOneScoreText.text = playerOneScore.ToString();
                counter = 3;
            }
            if (_playerOneRacingButtonsHold.PlayerOneSoon && _playerTwoRacingButtonsHold.PlayerTwoOnTime)
            {
                playerTwoScore++;
                playerTwoScoreText.text = playerTwoScore.ToString();

                counter = 3;
            }
            if(_playerOneRacingButtonsHold.PlayerOneSoon && _playerTwoRacingButtonsHold.PlayerTwoSoon)
            {
                _fireLightsScript.BothSoon = true;
                counter = 3;
            }

            //counter++;
        }
        if (counter == 3)
        {
            counter++;
            if (playerOneScore != 3 && playerTwoScore != 3)
            {
                StartCoroutine(WaitToUpdateGame());
            }
            if (playerOneScore == 3)
            {
                playerOneWin.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
            if (playerTwoScore == 3)
            {
                playerTwoWin.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
        }
    }

    private IEnumerator UpdatePlOneTimer()
    {
        while (!_playerOneRacingButtonsHold.PlayerOneOnTime)
        {
            playerOneTimer += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private IEnumerator UpdatePlTwoTimer()
    {
        while (!_playerTwoRacingButtonsHold.PlayerTwoOnTime)
        {
            playerTwoTimer += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

    }
    public IEnumerator WaitToUpdateGame()
    {
        yield return new WaitForSeconds(0.7f);
        counter = 0;
        playerOneCounter = 0;
        playerTwoCounter = 0;
        _fireLightsScript.CanHoldOff = false;
        _playerOneRacingButtonsHold.PlayerOneSoon = false;
        _playerTwoRacingButtonsHold.PlayerTwoSoon = false;
        _playerOneRacingButtonsHold.PlayerOneOnTime = false;
        _playerTwoRacingButtonsHold.PlayerTwoOnTime = false;
        _playerOneRacingButtonsHold.PlayerOneIsHolding = false;
        _playerTwoRacingButtonsHold.PlayerTwoIsHolding = false;
        _playerOneRacingButtonsHold.PlayerOneButton.interactable = true;
        _playerTwoRacingButtonsHold.PlayerTwoButton.interactable = true;
        _playerTwoRacingButtonsHold.SingleCounter = 0;
        _fireLightsScript.StartGame = false;
        _fireLightsScript.Counter = 0;
        _playerOneRacingButtonsHold.CantHold = false;
        _playerTwoRacingButtonsHold.CantHold = false;
        StopCoroutine(UpdatePlOneTimer());
        StopCoroutine(UpdatePlTwoTimer());
        playerOneTimerText.text = "";
        playerTwoTimerText.text = "";
    }
    public IEnumerator WaitToFinish()
    {

        _playerOneRacingButtonsHold.CantHold = true;
        _playerTwoRacingButtonsHold.CantHold = true;
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
