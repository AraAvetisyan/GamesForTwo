
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
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
    private int Counter;
    private float timerForGame;
    private float compareForOne, compareForTwo;
    [SerializeField] private GameObject endPanel;

    [SerializeField] private bool playerOnePressed, playerTwoPressed;
    [SerializeField] private Button playerOneButton, playerTwoButton;

    private bool gameEnds;

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
    [SerializeField] private AudioSource music, buttonSound;
    [SerializeField] private AudioSource buttonSoundBlue, buttonSoundRed;

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
        }
        if (isSingle)
        {
            playerOneButton.interactable = false;
        }

        if (isMobile && !isSingle)
        {
            playerOneTimer.transform.rotation = Quaternion.Euler(0, 0, 180);
            targetPlOne.transform.rotation = Quaternion.Euler(0, 0, 180);
            diferencePlOne.transform.rotation = Quaternion.Euler(0, 0, 180);

        }
        if (isSingle || !isMobile)
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
            targetPlOne.text = "ЦЕЛЕВОЕ ВРЕМЯ " + timerForGame.ToString();
            targetPlTwo.text = "ЦЕЛЕВОЕ ВРЕМЯ " + timerForGame.ToString();
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
        if (isSingle)
        {
            buttonOne.SetActive(false);

        }
        StartCoroutine(CloseTimer());
    }
    public IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds(2.25f);
        timerObject.SetActive(false);
    }
    public void PressedPlOneButton()
    {
        buttonSoundBlue.Play();
        playerOneNotPressedImage.SetActive(false);
        playerOnePressedImage.SetActive(true);
        playerOneButton.interactable = false;
        playerOnePressed = true;
        Counter++;
        playerOneStop = true;
        playerOneTime = timer;
        if (playerOneTime > timerForGame)
        {
            diferenceOne = playerOneTime - timerForGame;
        }

    }
    public void PressedPlTwoButton()
    {
        buttonSoundRed.Play();
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
        if (timer >= 3 && !gameEnds && testCounter == 0)
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

        if (playerOneTime < timerForGame)
        {
            compareForOne = timerForGame - playerOneTime;
        }
        else if (playerOneTime > timerForGame)
        {
            compareForOne = playerOneTime - timerForGame;
        }

        if (playerTwoTime < timerForGame)
        {
            compareForTwo = timerForGame - playerTwoTime;
        }
        else if (playerTwoTime > timerForGame)
        {
            compareForTwo = playerTwoTime - timerForGame;
        }



        StartCoroutine(WaitEnd());

    }
    public IEnumerator WaitEnd()
    {
        music.Stop();
        if (Geekplay.Instance.language == "en")
        {
            diferencePlOne.text = "DIFFERENCE " + compareForOne.ToString("F2");
            diferencePlTwo.text = "DIFFERENCE " + compareForTwo.ToString("F2");
        }
        if (Geekplay.Instance.language == "ru")
        {
            diferencePlOne.text = "РАЗНИЦА " + compareForOne.ToString("F2");
            diferencePlTwo.text = "РАЗНИЦА " + compareForTwo.ToString("F2");
        }
        if (Geekplay.Instance.language == "tr")
        {
            diferencePlOne.text = "FARKLILIK " + compareForOne.ToString("F2");
            diferencePlTwo.text = "FARKLILIK " + compareForTwo.ToString("F2");
        }


        yield return new WaitForSeconds(1f);
        endPanel.SetActive(true);
        if (compareForOne < compareForTwo)
        {
            playerOneWinPC.SetActive(true);
        }
        else if (compareForTwo < compareForOne)
        {
            playerTwoWinPC.SetActive(true);
        }
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
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();

    }
    public void PressedRestart()
    {
        buttonSound.Play();
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
