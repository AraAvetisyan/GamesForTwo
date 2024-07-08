using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesForTwoButtons : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private bool isSingle;
    public void PressedChickenGameButton()
    {
        SceneManager.LoadScene("ChickenGame");
    }

    public void PressedGreenBallButton()
    {
        SceneManager.LoadScene("GreenBall");
    }

    public void PressedTimerGameButton()
    {
        SceneManager.LoadScene("TimerGame");
    }

    public void PressedRedCircleButton()
    {
        SceneManager.LoadScene("RedCircle");
    }

    public void PressedDinosaurGameButton()
    {
        SceneManager.LoadScene("DinosaurGame");
    }

    public void PressedCatPawButton()
    {
        SceneManager.LoadScene("CatPaw");
    }

    public void PressedSummoGame()
    {
        SceneManager.LoadScene("SummoGame");
    }

    public void PressedRacingLight()
    {
        SceneManager.LoadScene("RacingLight");
    }

    public void PressedUnicorn()
    {
        SceneManager.LoadScene("Unicorn");
    }

    public void PressedFootballBall()
    {
        SceneManager.LoadScene("FootballBall");
    }
    public void PressedCheckers()
    {

        PlayerPrefs.SetInt("VsCPU", 0);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        
        canvas.SetActive(false);
    }
    public void PressedGuardGame()
    {
        SceneManager.LoadScene("GuardGame");
    }
    public void PressedBowling()
    {
        SceneManager.LoadScene("Bowling");
    }
    public void PressedMathQuiz()
    {
        SceneManager.LoadScene("MathQuiz");
    }
}