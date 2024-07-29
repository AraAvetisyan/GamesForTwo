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
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedTimerGameButton()
    {
        SceneManager.LoadScene("TimerGameSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedRedCircleButton()
    {
        SceneManager.LoadScene("RedCircleSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedDinosaurGameButton()
    {
        SceneManager.LoadScene("DinosaurGameSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedCatPawButton()
    {
        SceneManager.LoadScene("CatPawSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedSummoGame()
    {
        SceneManager.LoadScene("SummoGameSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedRacingLight()
    {
        SceneManager.LoadScene("RacingLightSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedUnicorn()
    {
        SceneManager.LoadScene("UnicornSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedFootballBall()
    {
        SceneManager.LoadScene("FootballBallSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedGuardGame()
    {
        SceneManager.LoadScene("GuardGameSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedCheckers()
    {
       // Debug.Log("Menak");
        PlayerPrefs.SetInt("VsCPU", 1);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        Geekplay.Instance.ShowInterstitialAd();

        canvas.SetActive(false);
    }
    public void PressedBowling()
    {
        SceneManager.LoadScene("BowlingSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedMathQuiz()
    {
        SceneManager.LoadScene("MathQuizSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedPiranhaRush()
    {
        SceneManager.LoadScene("PiranhaRushSingle");
        Geekplay.Instance.ShowInterstitialAd();
    }
}
