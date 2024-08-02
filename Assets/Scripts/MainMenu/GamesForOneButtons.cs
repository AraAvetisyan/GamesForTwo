using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesForOneButtons : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private GameObject bowlingDis, catPawDis, checkersDis, dinoDis, footballDis, greenBallDis, guardGameDis, mathQuizDis, piranhaDis, racingLightDis, redCircleDis, summoDis, timerDis, unicornDis;
    [SerializeField] private AudioSource buttonSound;
    public void PressedChickenGameButton()
    {
        buttonSound.Play();
        SceneManager.LoadScene("ChickenGameSingle");
    }

    public void PressedGreenBallButton()
    {
        buttonSound.Play();
        greenBallDis.SetActive(true);
    }

    public void PressedTimerGameButton()
    {
        buttonSound.Play();
        timerDis.SetActive(true);
    }

    public void PressedRedCircleButton()
    {
        buttonSound.Play();
        redCircleDis.SetActive(true);
    }

    public void PressedDinosaurGameButton()
    {
        buttonSound.Play();
        dinoDis.SetActive(true);
    }

    public void PressedCatPawButton()
    {
        buttonSound.Play();
        catPawDis.SetActive(true);
    }

    public void PressedSummoGame()
    {
        buttonSound.Play();
        summoDis.SetActive(true);
    }

    public void PressedRacingLight()
    {
        buttonSound.Play();
        racingLightDis.SetActive(true);
    }

    public void PressedUnicorn()
    {
        buttonSound.Play();
        unicornDis.SetActive(true);
    }

    public void PressedFootballBall()
    {
        buttonSound.Play();
        footballDis.SetActive(true);
    }
    public void PressedGuardGame()
    {
        buttonSound.Play();
        guardGameDis.SetActive(true);
    }
    public void PressedCheckers()
    {
        buttonSound.Play();
        PlayerPrefs.SetInt("VsCPU", 1);
        checkersDis.SetActive(true);
    }
    public void PressedBowling()
    {
        buttonSound.Play();
        bowlingDis.SetActive(true);
    }
    public void PressedMathQuiz()
    {
        buttonSound.Play();
        mathQuizDis.SetActive(true);
    }
    public void PressedPiranhaRush()
    {
        buttonSound.Play();
        piranhaDis.SetActive(true);
    }
}
