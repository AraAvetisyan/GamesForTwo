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
    public bool PlOneWin, PlTwoWin;
    public int countLose;
    public bool plOneLose, plTwoLose;
    private bool draw;
    private bool isMobile;
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource end;
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
           

            StartCoroutine(WaitToFinal());
        }
        if (countLose == 2 && plOneLose && plTwoLose)
        {
            draw = true;
            StartCoroutine(WaitToFinal());
        }
        if (PlOneWin)
        {
            PlOneWin = false;
            plTwoLose = true;
            StartCoroutine(WaitToFinal());
        }
        if (PlTwoWin)
        {
            PlTwoWin = false;
            plOneLose = true;
            StartCoroutine(WaitToFinal());
        }

    }
    public IEnumerator WaitToFinal()
    {
        music.Stop();
        plOneRb.gravityScale = 0;
        plTwoRb.gravityScale = 0;
        plOneRb.bodyType = RigidbodyType2D.Static;
        plTwoRb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1f);
        end.Play();
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
