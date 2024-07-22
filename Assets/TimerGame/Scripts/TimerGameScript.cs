using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
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
    //[SerializeField] private GameObject timerClosePlOne1, timerClosePlOne2, timerClosePlOne3, timerClosePlOne4, timerClosePlOne5;
    //[SerializeField] private GameObject timerClosePlTwo1, timerClosePlTwo2, timerClosePlTwo3, timerClosePlTwo4, timerClosePlTwo5;

    [SerializeField] private GameObject playerTwoCloserOne, playerTwoCloserTwo;
    [SerializeField] private Transform playerTwoCloserOneGoal, playerTwoCloserTwoGoal;
    [SerializeField] private GameObject playerOneCloserOne, playerOneCloserTwo;
    [SerializeField] private Transform playerOneCloserOneGoal, playerOneCloserTwoGoal;

    [SerializeField] private GameObject playerOneNotPressedImage, playerOnePressedImage;
    [SerializeField] private GameObject playerTwoNotPressedImage, playerTwoPressedImage;
    private int testCounter;

    private bool isMobile;

    [SerializeField] private bool isSingle;
    [SerializeField] private GameObject buttonOne, buttonTwo;
    [SerializeField] private GameObject buttonBG;
    private float diferenceOne, diferenceTwo;
    [SerializeField] private GameObject timerObject;
    
    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            buttonBG.SetActive(false);
            isMobile = false;
            //if (!isSingle)
            //{
            //    buttonOne.SetActive(false);
            //    buttonTwo.SetActive(false);
            //    buttonBG.SetActive(false);
            //}
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
        if (Geekplay.Instance.language == "ru")
        {
            targetPlOne.text = "Öåëåâîå âðåìÿ " + timerForGame.ToString();
            targetPlTwo.text = "Öåëåâîå âðåìÿ " + timerForGame.ToString();
        }
        if (Geekplay.Instance.language == "en")
        {
            targetPlOne.text = "TARGET TIME " + timerForGame.ToString();
            targetPlTwo.text = "TARGET TIME " + timerForGame.ToString();
        }
        if (Geekplay.Instance.language == "tr")
        {
            targetPlOne.text = "Hedef Zaman " + timerForGame.ToString();
            targetPlTwo.text = "Hedef Zaman " + timerForGame.ToString();
        }

        StartCoroutine(CloseTimer());
    }
    public IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds(0.5f);
        timerObject.SetActive(false);
    }
    public void PressedPlOneButton()
    {
        playerOneNotPressedImage.SetActive(false);
        playerOnePressedImage.SetActive(true);
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
        playerTwoNotPressedImage.SetActive(false);
        playerTwoPressedImage.SetActive(true);
        playerTwoButton.interactable = false;
        playerTwoPressed = true;
        Counter++;
        playerTwoStop = true;
        playerTwoTime = timer;
    }
    private void Update()
    {
        if(timer >= 1 && !gameEnds && testCounter == 0)
        {
            if (playerTwoCloserOne.transform.position.y >= playerTwoCloserOneGoal.position.y)
            {
                playerTwoCloserOne.transform.Translate(Vector3.down * 2.5f * Time.deltaTime);
                playerOneCloserOne.transform.Translate(Vector3.down * 2.5f * Time.deltaTime);
                if (playerTwoCloserOne.transform.position.y <= playerTwoCloserOneGoal.position.y)
                {
                    testCounter++;
                }
            }
            if (playerTwoCloserTwo.transform.position.y <= playerTwoCloserTwoGoal.position.y)
            {
                playerTwoCloserTwo.transform.Translate(Vector3.down * 2.5f * Time.deltaTime);
                playerOneCloserTwo.transform.Translate(Vector3.down * 2.5f * Time.deltaTime);
                if (playerTwoCloserTwo.transform.position.y >= playerTwoCloserTwoGoal.position.y)
                {
                    testCounter++;
                }
            }

        }
      

        if (Counter == 2)
        {
            Counter++;
            playerTwoCloserOne.SetActive(false);
            playerTwoCloserTwo.SetActive(false);
            playerOneCloserOne.SetActive(false);
            playerOneCloserTwo.SetActive(false);
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
        //timerClosePlOne1.SetActive(false);
        //timerClosePlOne2.SetActive(false);
        //timerClosePlTwo1.SetActive(false);
        //timerClosePlTwo2.SetActive(false);
        //timerClosePlOne3.SetActive(false);
        //timerClosePlOne4.SetActive(false);
        //timerClosePlTwo3.SetActive(false);
        //timerClosePlTwo4.SetActive(false);
        //timerClosePlOne5.SetActive(false);
        //timerClosePlTwo5.SetActive(false);

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
        if (Geekplay.Instance.language == "en")
        {
            diferencePlOne.text = "DIFFERENCE " + compareForOne.ToString("F2");
            diferencePlTwo.text = "DIFFERENCE " + compareForTwo.ToString("F2");
        }
        if (Geekplay.Instance.language == "ru")
        {
            diferencePlOne.text = "ÐÀÇÍÈÖÀ " + compareForOne.ToString("F2");
            diferencePlTwo.text = "ÐÀÇÍÈÖÀ " + compareForTwo.ToString("F2");
        }
        if (Geekplay.Instance.language == "tr")
        {
            diferencePlOne.text = "FARKLILIK " + compareForOne.ToString("F2");
            diferencePlTwo.text = "FARKLILIK " + compareForTwo.ToString("F2");
        }


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
        Geekplay.Instance.ShowInterstitialAd();

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
        Geekplay.Instance.ShowInterstitialAd();
    }

}
