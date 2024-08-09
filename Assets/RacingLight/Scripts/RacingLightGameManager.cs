
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingLightGameManager : MonoBehaviour
{
    private float playerOneTimer, playerTwoTimer;

    public int counter;
    [SerializeField] private TextMeshProUGUI playerOneTimerText, playerTwoTimerText, playerOneTimerTextTwo, playerTwoTimerTextTwo;
    private int playerOneScore, playerTwoScore;
    [SerializeField] private TextMeshProUGUI playerOneScoreText, playerTwoScoreText;
    [SerializeField] RacingButtonsHold _playerOneRacingButtonsHold, _playerTwoRacingButtonsHold;
    [SerializeField] private FireLightsScript _fireLightsScript;
    private int playerOneCounter, playerTwoCounter;
  //  [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject playerOneTimerBG, playerTwoTimerBG;
    private bool plOneWin, plTwoWin;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource end;
    [SerializeField] private RacingLightInstruction _racingLightInstruction;
    [SerializeField] private GameObject holdRed, holdBlue;
    [SerializeField] private GameObject release;
    void Start()
    {
        if(_playerTwoRacingButtonsHold.IsMobile && !_playerTwoRacingButtonsHold.IsSingle)
        {
            playerOneScoreText.transform.rotation = Quaternion.Euler(0, 0, 180);
           // playerOneTimerText.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if(!_playerTwoRacingButtonsHold.IsMobile || _playerTwoRacingButtonsHold.IsSingle)
        {
            playerOneScoreText.transform.rotation = Quaternion.Euler(0, 0, 0);
           // playerOneTimerText.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


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
        if (counter == 1)
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
            playerOneTimerBG.SetActive(true);
            playerTwoTimerBG.SetActive(true);
            if (_playerTwoRacingButtonsHold.IsMobile && !_playerTwoRacingButtonsHold.IsSingle)
            {
                playerOneTimerBG.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (!_playerTwoRacingButtonsHold.IsMobile || _playerTwoRacingButtonsHold.IsSingle)
            {
                playerOneTimerBG.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
         //   _playerOneRacingButtonsHold.blockerOne.SetActive(false);
           // _playerOneRacingButtonsHold.blockerTwo.SetActive(false);
            if (_playerOneRacingButtonsHold.PlayerOneOnTime)
            {
                playerOneTimerText.text = playerOneTimer.ToString("F2");
                playerOneTimerTextTwo.text = playerOneTimer.ToString("F2");
            }
            if (_playerOneRacingButtonsHold.PlayerOneSoon)
            {
                if (Geekplay.Instance.language == "en")
                {
                    playerOneTimerText.text = "Failed";
                    playerOneTimerTextTwo.text = "Failed";
                }
                else if(Geekplay.Instance.language == "ru")
                {
                    playerOneTimerText.text = "Неудача";
                    playerOneTimerTextTwo.text = "Неудача";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    playerOneTimerText.text = "Başarısız";
                    playerOneTimerTextTwo.text = "Başarısız";
                }
            }
            if (_playerTwoRacingButtonsHold.PlayerTwoOnTime)
            {
                playerTwoTimerText.text = playerTwoTimer.ToString("F2");
                playerTwoTimerTextTwo.text = playerTwoTimer.ToString("F2");
            }
            if (_playerTwoRacingButtonsHold.PlayerTwoSoon)
            {
                if (Geekplay.Instance.language == "en")
                {
                    playerTwoTimerText.text = "Failed";
                    playerTwoTimerTextTwo.text = "Failed";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    playerTwoTimerText.text = "Неудача";
                    playerTwoTimerTextTwo.text = "Неудача";
                }
                else if(Geekplay.Instance.language == "tr")
                {
                    playerTwoTimerText.text = "Başarısız";
                    playerTwoTimerTextTwo.text = "Başarısız";
                }
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
            if (_playerOneRacingButtonsHold.PlayerOneSoon && _playerTwoRacingButtonsHold.PlayerTwoSoon)
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
                if (_playerTwoRacingButtonsHold.IsMobile && !_playerTwoRacingButtonsHold.IsSingle)
                {
                    //playerOneWinMobile.SetActive(true);
                }
                if (!_playerTwoRacingButtonsHold.IsMobile || _playerTwoRacingButtonsHold.IsSingle)
                {
                 //   playerOneWinPC.SetActive(true);
                }
                plOneWin = true;
                StartCoroutine(WaitToFinish());
            }
            if (playerTwoScore == 3)
            {
                if (_playerTwoRacingButtonsHold.IsMobile && !_playerTwoRacingButtonsHold.IsSingle)
                {
                 //   playerTwoWinMobile.SetActive(true);
                }
                if (!_playerTwoRacingButtonsHold.IsMobile || _playerTwoRacingButtonsHold.IsSingle)
                {
                  //  playerTwoWinPC.SetActive(true);
                }
                plTwoWin = true;
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
        yield return new WaitForSeconds(1.5f);
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
        release.SetActive(false);
        holdRed.SetActive(true);
        holdBlue.SetActive(true);
        _racingLightInstruction.Scaler();

        _playerTwoRacingButtonsHold.blockerOne.SetActive(false);
        _playerTwoRacingButtonsHold.blockerTwo.SetActive(false);
        _playerTwoRacingButtonsHold.SingleCounter = 0;
        _fireLightsScript.StartGame = false;
        _fireLightsScript.Counter = 0;
        _playerOneRacingButtonsHold.CantHold = false;
        _playerTwoRacingButtonsHold.CantHold = false;
        StopCoroutine(UpdatePlOneTimer());
        StopCoroutine(UpdatePlTwoTimer());
        playerOneTimerText.text = "";
        playerOneTimerTextTwo.text = "";
        playerTwoTimerText.text = "";
        playerTwoTimerTextTwo.text = "";
        _fireLightsScript.GreenLight1.SetActive(false);
        _fireLightsScript.GreenLight2.SetActive(false);
        _fireLightsScript.GreenLight3.SetActive(false);
        _fireLightsScript.GreenLight4.SetActive(false);
        _fireLightsScript.GreenLight5.SetActive(false);
        playerOneTimerBG.SetActive(false);
        playerTwoTimerBG.SetActive(false);
    }
    public IEnumerator WaitToFinish()
    {
        music.Stop();
        _playerOneRacingButtonsHold.CantHold = true;
        _playerTwoRacingButtonsHold.CantHold = true;
        yield return new WaitForSeconds(1f);
        end.Play();
        finalPanel.SetActive(true);
        if (plOneWin)
        {
            playerOneWinPC.SetActive(true);
        }
        if(plTwoWin)
        {
            playerTwoWinPC.SetActive(true);
        }
    }
}
