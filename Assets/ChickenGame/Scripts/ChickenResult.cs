using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenResult : MonoBehaviour
{
//    public GameObject playerOneWinMobile, playerTwoWinMobile;
    public GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject drawPlOnePC;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private Rigidbody2D plOneRb, plTwoRb; 
    public int countLose;
    public bool plOneLose, plTwoLose;
    private bool draw;
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
           // playerTwoWinPC.SetActive(true);
            StartCoroutine(WaitToFinal());

        }
        if (countLose == 1 && plTwoLose)
        {
            //if (isMobile && !isSingle)
            //{
            //    playerOneWinMobile.SetActive(true);
            //}
            //if (isMobile || isSingle)
            //{
            //    playerOneWinPC.SetActive(true);
            //}
            //if(!isMobile && !isSingle)
            //{
            //    playerOneWinPC.SetActive(true);
            //}
            //if(!isMobile && isSingle)
            //{
            //    playerOneWinPC.SetActive(true);
            //}

            StartCoroutine(WaitToFinal());
        }
        if (countLose == 2 && plOneLose && plTwoLose)
        {
            //playerOneWinMobile.SetActive(false);
            //playerOneWinPC.SetActive(false);
            //playerTwoWinPC.SetActive(false);
            //drawPlTwoPC.SetActive(true);
            //if (isMobile && !isSingle)
            //{
            //    drawPlOneMobile.SetActive(true);
            //}
            //if (!isMobile || isSingle)
            //{
            //    drawPlOnePC.SetActive(true);
            //}
            draw = true;
            StartCoroutine(WaitToFinal());
        }

    }
    public IEnumerator WaitToFinal()
    {
        plOneRb.gravityScale = 0;
        plTwoRb.gravityScale = 0;
        plOneRb.bodyType = RigidbodyType2D.Static;
        plTwoRb.bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
        if (plOneLose)
        {
            playerTwoWinPC.SetActive(true);
        }
        if (plTwoLose)
        {
            playerOneWinPC.SetActive(true);
        }
        if (draw)
        {
            drawPlOnePC.SetActive(true);
        }
    }
}
