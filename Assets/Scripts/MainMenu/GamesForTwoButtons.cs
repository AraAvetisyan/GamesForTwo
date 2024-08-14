using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesForTwoButtons : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private GameObject bowlingDis, catPawDis, checkersDis, dinoDis, footballDis, greenBallDis, guardGameDis, mathQuizDis, piranhaDis, racingLightDis, redCircleDis, summoDis, timerDis, unicornDis;
    [SerializeField] private GameObject bowlingDisMobile, catPawDisMobile, checkersDisMobile, dinoDisMobile, footballDisMobile, greenBallDisMobile, guardGameDisMobile, mathQuizDisMobile, piranhaDisMobile, racingLightDisMobile, redCircleDisMobile, summoDisMobile, timerDisMobile, unicornDisMobile;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private bool isMobile;
    private void Start()
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
    public void PressedChickenGameButton()
    {
        buttonSound.Play();
        SceneManager.LoadScene("ChickenGame");
    }

    public void PressedGreenBallButton()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            greenBallDis.SetActive(true);
        }
        if (isMobile)
        {
            greenBallDisMobile.SetActive(true);
        }
    }

    public void PressedTimerGameButton()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            timerDis.SetActive(true);
        }
        if (isMobile)
        {
            timerDisMobile.SetActive(true);
        }
    }

    public void PressedRedCircleButton()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            redCircleDis.SetActive(true);
        }
        if (isMobile)
        {
            redCircleDisMobile.SetActive(true);
        }
    }

    public void PressedDinosaurGameButton()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            dinoDis.SetActive(true);
        }
        if(isMobile)
        {
            dinoDisMobile.SetActive(true);
        }
    }

    public void PressedCatPawButton()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            catPawDis.SetActive(true);
        }
        if (isMobile)
        {
            catPawDisMobile.SetActive(true);
        }
    }

    public void PressedSummoGame()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            summoDis.SetActive(true);
        }
        if (isMobile)
        {
            summoDisMobile.SetActive(true);
        }
    }

    public void PressedRacingLight()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            racingLightDis.SetActive(true);
        }
        if (isMobile)
        {
            racingLightDisMobile.SetActive(true);
        }
    }

    public void PressedUnicorn()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            unicornDis.SetActive(true);
        }
        if(isMobile)
        {
            unicornDisMobile.SetActive(true);
        }
    }

    public void PressedFootballBall()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            footballDis.SetActive(true);
        }
        if (isMobile)
        {
            footballDisMobile.SetActive(true);
        }
    }
    public void PressedCheckers()
    {
        buttonSound.Play();
        PlayerPrefs.SetInt("VsCPU", 0);
        checkersDis.SetActive(true);      
    }
    public void PressedGuardGame()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            guardGameDis.SetActive(true);
        }
        if (isMobile)
        {
            guardGameDisMobile.SetActive(true);
        }
    }
    public void PressedBowling()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            bowlingDis.SetActive(true);
        }
        if (isMobile)
        {
            bowlingDisMobile.SetActive(true);
        }
    }
    public void PressedMathQuiz()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            mathQuizDis.SetActive(true);
        }
        if (isMobile)
        {
            mathQuizDisMobile.SetActive(true);
        }
    }
    public void PressedPiranhaRush()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            piranhaDis.SetActive(true);
        }
        if (isMobile)
        {
            piranhaDisMobile.SetActive(true);
        }
    }
}