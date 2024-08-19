using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.AudioSettings;

public class GuardTimer : MonoBehaviour
{
    private int seconds = 30;
    private int newSeconds = 30;
    [SerializeField] private TextMeshProUGUI timerText;
    public bool GameEnds;
    [SerializeField] private Transform playerOneStartPos, playerTwoStartPos;
    [SerializeField] private GameObject playerOne, playerTwo;
    [SerializeField] private GameObject lightOne, lightTwo;
    [SerializeField] private GameObject blueRobber, blueGuard;
    [SerializeField] private GameObject redRobber, redGuard;
    [SerializeField] private JoystickPlayerExample playerOneJoystic, playerTwoJoystic;
    [SerializeField] private CoinTrigger _coinTriggerPlOne, _coinTriggerPlTwo;
    [SerializeField] private GameObject plOneWinPC, plTwoWinPC, drawOnePC;
    bool playerOneWin, playerTwoWin;
    public bool IsMobile;
    public bool IsSingle; 

    public bool IsSecondGame;
    public bool SecondGameEnds;

    [SerializeField] private PlayersTrigger _playersTrigger;
    public int Test;

    [SerializeField] private GameObject finalPanel;
    [SerializeField] Rigidbody2D rbPlOne, rbPlTwo;
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject end;
    [SerializeField] private AudioSource lightSound;
    void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
           
        }
        else
        {
            IsMobile = false;
           
        }
        timerText.text = "";
       // StartCoroutine(Timer());
    }
    private void Start()
    {
        Test = 1;
    }
    private void Update()
    {

        if (!IsSecondGame && GameEnds)
        {
            StopCoroutine(Timer());
            seconds = 0;
            newSeconds = 0;
            GameEnds = false;
            playerOne.transform.position = playerOneStartPos.position;
            playerTwo.transform.position = playerTwoStartPos.position;
            lightOne.SetActive(true);
            redGuard.SetActive(true);
            redRobber.SetActive(false);
            lightTwo.SetActive(false);
            blueRobber.SetActive(true);
            blueGuard.SetActive(false);
            playerOne.tag = "Guard";
            playerTwo.tag = "Robber";
            newSeconds = 30;
            //StartCoroutine(SecondTimer());
        }
        if (IsSecondGame && GameEnds)
        {
            StopCoroutine(Timer());
            seconds = 0;
            newSeconds = 0;
            GameEnds = false;
            playerOne.transform.position = playerOneStartPos.position;
            playerTwo.transform.position = playerTwoStartPos.position;
            lightOne.SetActive(false);
            redGuard.SetActive(false);
            redRobber.SetActive(true);
            lightTwo.SetActive(true);
            blueRobber.SetActive(false);
            blueGuard.SetActive(true);
            playerOne.tag = "Robber";
            playerTwo.tag = "Guard";
            newSeconds = 30;

          //  StartCoroutine(SecondTimer());
        }
        if(_coinTriggerPlOne.CoinCount >= 5)
        {
            playerOneJoystic.enabled = false;
            playerTwoJoystic.enabled = false;

            playerOneWin = true;

            StartCoroutine(WaitToFinish());
        }
        if(_coinTriggerPlTwo.CoinCount >= 5)
        {
            playerOneJoystic.speed = 0;
            playerTwoJoystic.speed = 0;
          
            playerTwoWin = true;

            StartCoroutine(WaitToFinish());
        }
    }
    public IEnumerator WaitToFinish()
    {
        music.Stop();
        rbPlOne.isKinematic = true;
        rbPlTwo.isKinematic = true;
        rbPlOne.velocity= Vector2.zero;
        rbPlTwo.velocity= Vector2.zero;
        yield return new WaitForSeconds(1f);
        lightSound.volume = 0;
        end.SetActive(true);
        finalPanel.SetActive(true);
        if (playerOneWin)
        {
            plOneWinPC.SetActive(true);
        }
        if (playerTwoWin)
        {
            plTwoWinPC.SetActive(true);
        }
    }
    public IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        seconds--;
        
        if (seconds <= 0)
        {
            seconds = 0;
        }
        if (seconds >= 10)
        {
            timerText.text = seconds.ToString();
        }
        else
        {
            timerText.text = "0" + seconds.ToString();
        }

        if (seconds > 0 && !IsSecondGame)
        {
            StartCoroutine(Timer());
        }
    }
    public IEnumerator SecondTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        if (Test == 1)
        {
            newSeconds--;

            if (newSeconds <= 0)
            {
                newSeconds = 0;
                _playersTrigger.GuardWin = true;
            }
            if (newSeconds >= 10)
            {
                timerText.text = newSeconds.ToString();
            }
            else
            {
                timerText.text = "0" + newSeconds.ToString();
            }

            if (SecondGameEnds)
            {
                newSeconds = 0;

            }
            if (newSeconds > 0 && Test == 1)
            {
                StartCoroutine(SecondTimer());
            }
           
        }      
    }

}

