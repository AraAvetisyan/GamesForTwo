using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerGameScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneTimer, playerTwoTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private bool playerOneStop, playerTwoStop;
    [SerializeField] private float playerOneTime, playerTwoTime;
    [SerializeField] private float timer;
    [SerializeField] private GameObject PlayerOneWin, PlayerTwoWin;
    private int Counter;
    private float timerForGame;
    private float compareForOne, compareForTwo;
    [SerializeField] private GameObject endPanel;

    [SerializeField] private bool playerOnePressed, playerTwoPressed;
    [SerializeField] private Button playerOneButton, playerTwoButton;

    private bool gameEnds;
    [SerializeField] private GameObject timerClosePlOne1, timerClosePlOne2, timerClosePlOne3, timerClosePlOne4, timerClosePlOne5;
    [SerializeField] private GameObject timerClosePlTwo1, timerClosePlTwo2, timerClosePlTwo3, timerClosePlTwo4, timerClosePlTwo5;

    private bool isMobile;

    [SerializeField] private bool isSingle;
    private void Start()
    {
        //if (Geekplay.Instance.mobile)
        //{
        //    isMobile = true;
        //    Debug.Log("IsMobile");
        //}
        //else
        //{
        //    isMobile = false;
        //}
      
        StartCoroutine(UpdatePlOneTimer());
        StartCoroutine(UpdatePlTwoTimer());

        timerForGame = Random.Range(5, 31);
        timerText.text = timerForGame.ToString("F1");
        if (isSingle)
        {
            StartCoroutine(Single());
        }
    }

    public void PressedPlOneButton()
    {
        playerOneButton.interactable = false;
        playerOnePressed = true;
        Counter++;
        playerOneStop = true;
        playerOneTime = timer;
    }
    public void PressedPlTwoButton()
    {
        playerTwoButton.interactable = false;
        playerTwoPressed = true;
        Counter++;
        playerTwoStop = true;
        playerTwoTime = timer;
    }
    private void Update()
    {
        if(timer >= 1 && !gameEnds)
        {
            timerClosePlOne1.SetActive(true);
            timerClosePlOne2.SetActive(true);
            timerClosePlTwo1.SetActive(true);
            timerClosePlTwo2.SetActive(true);
        }
        if(timer >= 2 && !gameEnds)
        {
            timerClosePlOne3.SetActive(true);
            timerClosePlOne4.SetActive(true);
            timerClosePlTwo3.SetActive(true);
            timerClosePlTwo4.SetActive(true);
        }
        if(timer >= 3 && !gameEnds)
        {
            timerClosePlOne5.SetActive(true);
            timerClosePlTwo5.SetActive(true);
        }

        if (Counter == 2)
        {
            Counter++;
            EndGame();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.Z) && !playerTwoPressed)
        {
            PressedPlTwoButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && !isSingle && !playerOnePressed)
        {
            PressedPlOneButton();
        }
    }
    public IEnumerator Single()
    {
        float singleTimer = Random.Range(timerForGame - 2, timerForGame + 1);
        yield return new WaitForSecondsRealtime(singleTimer);
        PressedPlOneButton();

    }
    public void EndGame()
    {
        gameEnds = true;
        timerClosePlOne1.SetActive(false);
        timerClosePlOne2.SetActive(false);
        timerClosePlTwo1.SetActive(false);
        timerClosePlTwo2.SetActive(false);
        timerClosePlOne3.SetActive(false);
        timerClosePlOne4.SetActive(false);
        timerClosePlTwo3.SetActive(false);
        timerClosePlTwo4.SetActive(false);
        timerClosePlOne5.SetActive(false);
        timerClosePlTwo5.SetActive(false);

        if (playerOneTime < timerForGame)
        {
            compareForOne = timerForGame - playerOneTime;
        }
        else if (playerOneTime > timerForGame)
        {
            compareForOne = playerOneTime - timerForGame;
        }

        if(playerTwoTime < timerForGame)
        {
            compareForTwo = timerForGame - playerTwoTime;
        }
        else if(playerTwoTime > timerForGame)
        {
            compareForTwo= playerTwoTime - timerForGame;
        }


        if(compareForOne < compareForTwo) 
        {
            PlayerOneWin.SetActive(true);
            StartCoroutine(WaitEnd());
            
        }
        else if(compareForTwo < compareForOne)
        {
           PlayerTwoWin.SetActive(true);
           StartCoroutine (WaitEnd());
        }

    }
    public IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(1.5f);
        endPanel.SetActive(true);
    }
    private IEnumerator UpdatePlOneTimer()
    {
        while (!playerOneStop) 
        {
            timer += 0.01f; 
            UpdatePlOneTimerText(); 
            yield return new WaitForSeconds(0.01f); 
        }

    }
    private void UpdatePlOneTimerText()
    {
        
        playerOneTimer.text = timer.ToString("F2");
    }

    private IEnumerator UpdatePlTwoTimer()
    {
        while (!playerTwoStop)
        {
            timer += 0.01f;
            UpdatePlTwoTimerText();
            yield return new WaitForSeconds(0.01f);
        }

    }
    private void UpdatePlTwoTimerText()
    {
       
        playerTwoTimer.text = timer.ToString("F2");
    }

    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void PressedRestart()
    {
        SceneManager.LoadScene("TimerGame");
    }

}
