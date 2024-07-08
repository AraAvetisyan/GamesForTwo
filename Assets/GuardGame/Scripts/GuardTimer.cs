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
    [SerializeField] private JoystickPlayerExample playerOneJoystic, playerTwoJoystic;
    [SerializeField] private CoinTrigger _coinTriggerPlOne, _coinTriggerPlTwo;
    [SerializeField] private GameObject plOneWinMobile, plTwoWinMobile, drawOneMobile, drawTwoMobile;
    [SerializeField] private GameObject plOneWinPC, plTwoWinPC, drawOnePC, drawTwoPC;
    public bool IsMobile;
    public bool IsSingle; 

    public bool IsSecondGame;
    public bool SecondGameEnds;

    [SerializeField] private GameObject finalPanel;
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
        StartCoroutine(Timer());
    }
    private void Update()
    {

        if (!IsSecondGame && GameEnds)
        {
            StopCoroutine(Timer());
            seconds = 0;
            GameEnds = false;
            IsSecondGame = true;
            playerOne.transform.position = playerOneStartPos.position;
            playerTwo.transform.position = playerTwoStartPos.position;
            lightOne.SetActive(true);
            lightTwo.SetActive(false);
            playerOne.tag = "Guard";
            playerTwo.tag = "Robber";
            newSeconds = 30;
            StartCoroutine(SecondTimer());
        }
        if (IsSecondGame && SecondGameEnds)
        {
            StopCoroutine(SecondTimer());
            newSeconds = 0;
            GameEnds = false;
            IsSecondGame = false;
            playerOne.transform.position = playerOneStartPos.position;
            playerTwo.transform.position = playerTwoStartPos.position;
            //playerOneJoystic.speed = 0;
            //playerTwoJoystic.speed = 0;
            playerOneJoystic.enabled = false;
            playerTwoJoystic.enabled = false;
            if (_coinTriggerPlOne.CoinCount > _coinTriggerPlTwo.CoinCount)
            {
                if (IsMobile && !IsSingle)
                {
                    plOneWinMobile.SetActive(true);
                }
                if (!IsMobile || IsSingle)
                {
                    plOneWinPC.SetActive(true);
                }
            }
            if (_coinTriggerPlTwo.CoinCount > _coinTriggerPlOne.CoinCount)
            {
                if (IsMobile && !IsSingle)
                {
                    plTwoWinMobile.SetActive(true);
                }
                if (!IsMobile || IsSingle)
                {
                    plTwoWinPC.SetActive(true);
                }
            }
            if (_coinTriggerPlOne.CoinCount == _coinTriggerPlTwo.CoinCount)
            {
                if (IsMobile && !IsSingle)
                {
                    drawOneMobile.SetActive(true);
                    drawTwoMobile.SetActive(true);
                }
                if (!IsMobile || IsSingle)
                {
                    drawOnePC.SetActive(true);
                    drawTwoPC.SetActive(true);
                }
            }

            StartCoroutine(WaitToFinish());
        }
    }
    public IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
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

        if (seconds > 0 )
        {
            Debug.Log(("Seconds Debug: ") + seconds);
            StartCoroutine(Timer());
        }
        else
        {

            GameEnds = true;
        }
    }
    public IEnumerator SecondTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        newSeconds--;

        if (newSeconds <= 0)
        {
            newSeconds = 0;
            SecondGameEnds = true;
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
        if (newSeconds > 0)
        {
            Debug.Log(("New Seconds Debug: ") + newSeconds);
            StartCoroutine(SecondTimer());
        }
    }

}
