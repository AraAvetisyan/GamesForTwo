using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;
using Random = UnityEngine.Random;

public class DinosaurGame : MonoBehaviour
{
    [SerializeField] private Button[] teeth;
    private int lose;
    [SerializeField] private GameObject dino;
    [SerializeField] private GameObject dinoGameOver;
    int player;
    [SerializeField] GameObject playerOneWinPC, playerTwoWinPC;
    private int counter;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject plOne, plTwo, plOnePC;
    [SerializeField] private GameObject plOneTurn, plTwoTurn;
    private bool change;
    private bool gameIsOver;
    [SerializeField] private List<int> singleTeeth;
    private int teethIndex;
    [SerializeField] private bool isSingle;
    [SerializeField] private bool isMobile;
    [SerializeField] private GameObject[] pressedTeeth;
    private bool pressed;
    public int teethToPress;
    public bool playerOneWinnerBool, playerTwoWinnerBool;

    [SerializeField] private AudioSource presedAudio, wrongAudio, buttonSound;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource end;
    private void Awake()
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
    void Start()
    {
        lose = UnityEngine.Random.Range(0, 9);
        player = UnityEngine.Random.Range(0, 2);
        if (player == 0)
        {
            if (isMobile && !isSingle)
            {
                plOne.SetActive(true);
            }
            if (isMobile && isSingle)
            {
                plOnePC.SetActive(true);
            }
            if (!isMobile && !isSingle)
            {
                plOnePC.SetActive(true);
            }
            if (!isMobile && isSingle)
            {
                plOnePC.SetActive(true);
            }
            plOneTurn.SetActive(true);
            if (isSingle)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                StartCoroutine(Single());
            }
        }
        if (player == 1)
        {
            plTwo.SetActive(true);
            plTwoTurn.SetActive(true);
        }

    }


    public void PressedTeetth(int index)
    {
        presedAudio.Play();
        if (isSingle)
        {
            for (int i = 0; i < singleTeeth.Count; i++)
            {
                if (singleTeeth[i] == index)
                {
                    singleTeeth.RemoveAt(i);
                }
            }

        }
        change = true;
        teeth[index].interactable = false;
        teeth[index].gameObject.SetActive(false);
        pressedTeeth[index].SetActive(true);
        counter++;
        if (player == 1 && change && !gameIsOver)
        {
            change = false;
            player = 0;
            plTwo.SetActive(false);
            if (isMobile && !isSingle)
            {
                plOne.SetActive(true);
            }
            if (isMobile && isSingle)
            {
                plOnePC.SetActive(true);
            }
            if (!isMobile && !isSingle)
            {
                plOnePC.SetActive(true);
            }
            if (!isMobile && isSingle)
            {
                plOnePC.SetActive(true);
            }
            if (index != lose)
            {
                plOneTurn.SetActive(true);
                plTwoTurn.SetActive(false);
            }
            if (isSingle)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                StartCoroutine(Single());
            }
        }
        if (player == 0 && change && !gameIsOver)
        {
            change = false;
            player = 1;
            plOne.SetActive(false);
            plOnePC.SetActive(false);
            if (index != lose)
            {
                plOneTurn.SetActive(false);
                plTwoTurn.SetActive(true);
            }
            plTwo.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (index == lose)
        {
            wrongAudio.Play();
            gameIsOver = true;
            dino.SetActive(false);
            dinoGameOver.SetActive(true);
            if (player == 0)
            {
                if (isMobile && !isSingle)
                {
                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (!isMobile || isSingle)
                {

                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plOnePC.SetActive(false);
                if (index != lose)
                {
                    plTwoTurn.SetActive(false);
                    plOneTurn.SetActive(true);
                }
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;

                }
                playerOneWinnerBool = true;
            }
            if (player == 1)
            {
                if (isMobile && !isSingle)
                {
                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (!isMobile || isSingle)
                {
                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plOnePC.SetActive(false);
                if (index != lose)
                {
                    plTwoTurn.SetActive(true);
                    plOneTurn.SetActive(false);
                }
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                }
                playerTwoWinnerBool = true;
            }

            StartCoroutine(WaitToFinal());
        }
        if (counter == 9)
        {
            gameIsOver = true;
            dino.SetActive(false);
            dinoGameOver.SetActive(true);
            if (player == 0)
            {
                if (isMobile && !isSingle)
                {
                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (!isMobile || isSingle)
                {
                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plOnePC.SetActive(false);
                if (index != lose)
                {
                    plTwoTurn.SetActive(false);
                    plOneTurn.SetActive(true);
                }
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                }
            }
            if (player == 1)
            {
                if (isMobile && !isSingle)
                {
                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (!isMobile || isSingle)
                {
                    plOne.SetActive(false);
                    plOnePC.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plOnePC.SetActive(false);
                if (index != lose)
                {
                    plTwoTurn.SetActive(true);
                    plOneTurn.SetActive(false);
                }
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                }
            }
        }

    }
    public IEnumerator Single()
    {
        pressed = false;
        float timeToPress = Random.Range(1.2f, 1.5f);
        yield return new WaitForSeconds(timeToPress);
        teethIndex = UnityEngine.Random.Range(0, singleTeeth.Count);

        teethToPress = singleTeeth[teethIndex];
        PressedTeetth(teethToPress);

    }
    public IEnumerator WaitToFinal()
    {
        music.Stop();
        yield return new WaitForSeconds(2f);
        end.Play();
        finalPanel.SetActive(true);
        if (playerOneWinnerBool)
        {
            playerOneWinPC.SetActive(true);
        }
        if (playerTwoWinnerBool)
        {
            playerTwoWinPC.SetActive(true);
        }
    }


    public void PressedHome()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRest()
    {
        buttonSound.Play();
        if (!isSingle)
        {
            SceneManager.LoadScene("DinosaurGame");
        }
        if (isSingle)
        {
            SceneManager.LoadScene("DinosaurGameSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }

}