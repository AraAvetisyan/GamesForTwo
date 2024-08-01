using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesForOneButtons : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private GameObject bowlingDis, catPawDis, checkersDis, chickenDis, dinoDis, footballDis, greenBallDis, guardGameDis, mathQuizDis, piranhaDis, racingLightDis, redCircleDis, summoDis, timerDis, unicornDis;
    public void PressedChickenGameButton()
    {
        chickenDis.SetActive(true);
    }

    public void PressedGreenBallButton()
    {
        greenBallDis.SetActive(true);
    }

    public void PressedTimerGameButton()
    {
        timerDis.SetActive(true);
    }

    public void PressedRedCircleButton()
    {
        redCircleDis.SetActive(true);
    }

    public void PressedDinosaurGameButton()
    {
        dinoDis.SetActive(true);
    }

    public void PressedCatPawButton()
    {       
        catPawDis.SetActive(true);
    }

    public void PressedSummoGame()
    {
        summoDis.SetActive(true);
    }

    public void PressedRacingLight()
    {
        racingLightDis.SetActive(true);
    }

    public void PressedUnicorn()
    {
        unicornDis.SetActive(true);
    }

    public void PressedFootballBall()
    {
        footballDis.SetActive(true);
    }
    public void PressedGuardGame()
    {
        guardGameDis.SetActive(true);
    }
    public void PressedCheckers()
    {        
        PlayerPrefs.SetInt("VsCPU", 1);
        checkersDis.SetActive(true);
    }
    public void PressedBowling()
    {      
        bowlingDis.SetActive(true);
    }
    public void PressedMathQuiz()
    {
        mathQuizDis.SetActive(true);
    }
    public void PressedPiranhaRush()
    {
        piranhaDis.SetActive(true);
    }
}
