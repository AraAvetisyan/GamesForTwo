using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DinosaurGame : MonoBehaviour
{
    [SerializeField] private Button[] teeth;
    private int lose;
    [SerializeField] private GameObject dino;
    int player;
    [SerializeField] GameObject playerOneWin, playerTwoWin;
    private int counter;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject plOne, plTwo;
    private bool change;

    [SerializeField] private List<int> singleTeeth;
    private int teethIndex;
    [SerializeField] bool isSingle;


    void Start()
    {
        
           
        
        lose = Random.Range(0, 9);
        player = Random.Range(0, 2);
        Debug.Log(lose);
        if(player == 0)
        {
            plOne.SetActive(true);
            if (isSingle)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                StartCoroutine(Single());
            }
        }
        if(player == 1)
        {
            plTwo.SetActive(true);
        }
       
    }
    

    public void PressedTeetth(int index)
    {
        singleTeeth.RemoveAt(index);
        change = true;
        teeth[index].interactable = false;
        counter++;
        Debug.Log(player);

        if (index == lose)
        {
            if(player == 0)
            {
                playerTwoWin.SetActive(true);
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                    
                }
            }
            if(player == 1)
            {
                playerOneWin.SetActive(true);
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                }
            }
        }
        if(counter == 9)
        {
            if(player == 0)
            {
                playerOneWin.SetActive(true);
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                }
            }
            if (player == 1)
            {
                playerTwoWin.SetActive(true);
                StartCoroutine(WaitToFinal());
                for (int i = 0; i < teeth.Length; i++)
                {
                    teeth[i].interactable = false;
                }
            }
        }
        if (player == 1 && change)
        {
            change = false;
            player = 0;
            plTwo.SetActive(false);
            plOne.SetActive(true);
            if (isSingle)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                StartCoroutine(Single());
            }
        }
        if (player == 0 && change)
        {
            change = false;
            player = 1;
            plOne.SetActive(false);
            plTwo.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public IEnumerator Single()
    {
        yield return new WaitForSeconds(0.5f);
        teethIndex = Random.Range(0, singleTeeth.Count);
        PressedTeetth(teethIndex);
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

   

