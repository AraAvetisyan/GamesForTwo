using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool isMobile;
    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
            Debug.Log("IsMobile");
        }
        else
        {
            isMobile = false;
        }
        StartCoroutine(UpdatePlOneTimer());
        StartCoroutine(UpdatePlTwoTimer());

        timerForGame = Random.Range(5, 31);
        timerText.text = timerForGame.ToString("F1");
    }

    public void PressedPlOneButton()
    {
        Counter++;
        playerOneStop = true;
        playerOneTime = timer;
    }
    public void PressedPlTwoButton()
    {
        Counter++;
        playerTwoStop = true;
        playerTwoTime = timer;
    }
    private void Update()
    {
        if (Counter == 2)
        {
            Counter++;
            EndGame();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.Z))
        {
            PressedPlTwoButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M))
        {
            PressedPlOneButton();
        }
    }
    public void EndGame()
    {
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
