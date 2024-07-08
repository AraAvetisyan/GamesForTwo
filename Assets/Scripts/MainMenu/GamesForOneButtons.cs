using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesForOneButtons : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private bool isSingle;
    public void PressedChickenGameButton()
    {
        SceneManager.LoadScene("ChickenGameSingle");
    }

    public void PressedGreenBallButton()
    {
        SceneManager.LoadScene("GreenBallSingle");
    }

    public void PressedTimerGameButton()
    {
        SceneManager.LoadScene("TimerGameSingle");
    }

    public void PressedRedCircleButton()
    {
        SceneManager.LoadScene("RedCircleSingle");
    }

    public void PressedDinosaurGameButton()
    {
        SceneManager.LoadScene("DinosaurGameSingle");
    }

    public void PressedCatPawButton()
    {
        SceneManager.LoadScene("CatPawSingle");
    }

    public void PressedSummoGame()
    {
        SceneManager.LoadScene("SummoGameSingle");
    }

    public void PressedRacingLight()
    {
        SceneManager.LoadScene("RacingLightSingle");
    }

    public void PressedUnicorn()
    {
        SceneManager.LoadScene("UnicornSingle");
    }

    public void PressedFootballBall()
    {
        SceneManager.LoadScene("FootballBallSingle");
    }
    public void PressedGuardGame()
    {
        SceneManager.LoadScene("GuardGameSingle");
    }
    public void PressedCheckers()
    {
        Debug.Log("Menak");
        PlayerPrefs.SetInt("VsCPU", 1);
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
       
        canvas.SetActive(false);
    }
    public void PressedBowling()
    {
        SceneManager.LoadScene("BowlingSingle");
    }
}
