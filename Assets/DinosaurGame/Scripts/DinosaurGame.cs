using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

public class DinosaurGame : MonoBehaviour
{
    [SerializeField] private Button[] teeth;
    private int lose;
    [SerializeField] private GameObject dino;
    [SerializeField] private GameObject dinoGameOver;
    int player;
    [SerializeField] GameObject playerOneWinMobile;
    [SerializeField] GameObject playerOneWinPC, playerTwoWinPC;
    private int counter;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject plOne, plTwo;
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
        Debug.Log(lose);
        if(player == 0)
        {
            Debug.Log("First");
            plOne.SetActive(true);
            plOneTurn.SetActive(true);
            if (isSingle)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                StartCoroutine(Single());
            }
        }
        if(player == 1)
        {
            Debug.Log("Second");
            plTwo.SetActive(true);
            plTwoTurn.SetActive(true);
        }
       
    }
    

    public void PressedTeetth(int index)
    {

        if (isSingle)
        {
            for(int i = 0; i < singleTeeth.Count; i++)
            {
                if(singleTeeth[i] == index)
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
            plOne.SetActive(true);
            plOneTurn.SetActive(true);
            plTwoTurn.SetActive(false);
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
            plOneTurn.SetActive(false);
            plTwoTurn.SetActive(true);
            plTwo.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (index == lose)
        {
            gameIsOver = true;
            dino.SetActive(false);
            dinoGameOver.SetActive(true);
            if (player == 0)
            {
                if (isMobile && !isSingle)
                {
                    playerOneWinMobile.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if(!isMobile || isSingle)
                {
                    playerOneWinPC.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plTwoTurn.SetActive(false);
                plOneTurn.SetActive(true);
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                    
                }
            }
            if(player == 1)
            {
                if (isMobile && !isSingle)
                {
                    playerTwoWinPC.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (!isMobile || isSingle)
                {
                    playerTwoWinPC.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plTwoTurn.SetActive(true);
                plOneTurn.SetActive(false);
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                }
            }
        }
        if(counter == 9)
        {
            gameIsOver = true;
            dino.SetActive(false);
            dinoGameOver.SetActive(true);
            if (player == 0)
            {
                if (isMobile && !isSingle)
                {
                    playerOneWinMobile.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if(!isMobile || isSingle)
                {
                    playerOneWinPC.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plTwoTurn.SetActive(false);
                plOneTurn.SetActive(true);
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
                    playerTwoWinPC.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (!isMobile || isSingle)
                {
                    playerTwoWinPC.SetActive(true);
                    plOne.SetActive(false);
                    plTwo.SetActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                plTwo.SetActive(false);
                plOne.SetActive(false);
                plTwoTurn.SetActive(true);
                plOneTurn.SetActive(false);
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
        yield return new WaitForSeconds(0.5f);
        teethIndex = UnityEngine.Random.Range(0, singleTeeth.Count);
        
        teethToPress = singleTeeth[teethIndex];
         
        
        Debug.Log("AI pressed - " + teethToPress);
 


        
        
        PressedTeetth(teethToPress);
        
    }
    public IEnumerator WaitToFinal()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }


    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("DinosaurGame");
        }
        if (isSingle)
        {
            SceneManager.LoadScene("DinosaurGameSingle");
        }
    }
    
}

   

