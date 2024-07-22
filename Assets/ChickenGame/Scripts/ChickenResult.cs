using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AudioSettings;

public class ChickenResult : MonoBehaviour
{
    public GameObject playerOneWinMobile, playerTwoWinMobile;
    public GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject drawPlOneMobile, drawPlOnePC, drawPlTwoPC;
    public int countLose;
    public bool plOneLose, plTwoLose;
    private bool isMobile;
    [SerializeField] private bool isSingle;
    void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
          
        }
    }

    void Update()
    {
        if (countLose == 1 && plOneLose)
        {
            playerTwoWinPC.SetActive(true);
        }
        if (countLose == 1 && plTwoLose)
        {
            if (isMobile && !isSingle)
            {
                playerOneWinMobile.SetActive(true);
            }
            if (isMobile || isSingle)
            {
                playerOneWinPC.SetActive(true);
            }
            if(!isMobile && !isSingle)
            {
                playerOneWinPC.SetActive(true);
            }
            if(!isMobile && isSingle)
            {
                playerOneWinPC.SetActive(true);
            }
        }
        if (countLose == 2 && plOneLose && plTwoLose)
        {
            playerOneWinMobile.SetActive(false);
            playerOneWinPC.SetActive(false);
            playerTwoWinPC.SetActive(false);
            drawPlTwoPC.SetActive(true);
            if (isMobile && !isSingle)
            {
                drawPlOneMobile.SetActive(true);
            }
            if (!isMobile || isSingle)
            {
                drawPlOnePC.SetActive(true);
            }
        }

    }
}
