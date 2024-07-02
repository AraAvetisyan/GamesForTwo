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
    [SerializeField] private TextMeshProUGUI targetPlOne, targetPlTwo;
    [SerializeField] private TextMeshProUGUI diferencePlOne, diferencePlTwo;
    
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private bool playerOneStop, playerTwoStop;
    [SerializeField] private float playerOneTime, playerTwoTime;
    [SerializeField] private float timer;
    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
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
    [SerializeField] private GameObject buttonOne, buttonTwo;
    private float diferenceOne, diferenceTwo;
    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
            if (!isSingle)
            {
                buttonOne.SetActive(false);
                buttonTwo.SetActive(false);
            }
        }

        //if (!isMobile)
        //{
        //    playerOneTimer.transform.rotation = Quaternion.Euler(0, 0, 0);
        //    targetPlOne.transform.rotation = Quaternion.Euler(0, 0, 0);
        //    diferencePlOne.transform.rotation = Quaternion.Euler(0, 0, 0);

        //}

        if (isMobile && !isSingle)
        {
            Debug.Log("Mobile u erkusov");
            //                timerText.transform.rotation = Quaternion.Euler(0, 0, 180);
            playerOneTimer.transform.rotation = Quaternion.Euler(0, 0, 180);
            targetPlOne.transform.rotation = Quaternion.Euler(0, 0, 180);
            diferencePlOne.transform.rotation = Quaternion.Euler(0, 0, 180);

        }
        if(isSingle || !isMobile)
        {
            playerOneTimer.transform.rotation = Quaternion.Euler(0, 0, 0);
            targetPlOne.transform.rotation = Quaternion.Euler(0, 0, 0);
            diferencePlOne.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        StartCoroutine(UpdatePlOneTimer());
        StartCoroutine(UpdatePlTwoTimer());

        timerForGame = Random.Range(5, 15);
        timerText.text = timerForGame.ToString("F1");
        if (isSingle)
        {
            StartCoroutine(Single());
        }
        targetPlOne.text = "TARGET TIME " + timerForGame.ToString();
        targetPlTwo.text = "TARGET TIME " + timerForGame.ToString();
    }

    public void PressedPlOneButton()
    {
        playerOneButton.interactable = false;
        playerOnePressed = true;
        Counter++;
        playerOneStop = true;
        playerOneTime = timer;
        if(playerOneTime > timerForGame)
        {
            diferenceOne = playerOneTime - timerForGame;
        }
       
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
            if (isMobile && !isSingle)
            {
                playerOneWinMobile.SetActive(true);
            }
            if(!isMobile || isSingle)
            {
                playerOneWinPC.SetActive(true);
            }
            StartCoroutine(WaitEnd());
            
        }
        else if(compareForTwo < compareForOne)
        {
            if (isMobile && !isSingle)
            {
                playerTwoWinMobile.SetActive(true);
            }
            if (!isMobile || isSingle)
            {
                playerTwoWinPC.SetActive(true);
            }
            StartCoroutine (WaitEnd());
        }

    }
    public IEnumerator WaitEnd()
    {
        diferencePlOne.text = "DIFFERENCE " + compareForOne.ToString("F2");
        diferencePlTwo.text = "DIFFERENCE " + compareForTwo.ToString("F2");

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
        if (!isSingle)
        {
            SceneManager.LoadScene("TimerGame");
        }
        else
        {
            SceneManager.LoadScene("TimerGameSingle");

        } 
    }

}
