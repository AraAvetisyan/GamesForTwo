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
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedTimerGameButton()
    {
        SceneManager.LoadScene("TimerGame");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedRedCircleButton()
    {
        SceneManager.LoadScene("RedCircle");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedDinosaurGameButton()
    {
        SceneManager.LoadScene("DinosaurGame");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedCatPawButton()
    {
        SceneManager.LoadScene("CatPaw");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedSummoGame()
    {
        SceneManager.LoadScene("SummoGame");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedRacingLight()
    {
        SceneManager.LoadScene("RacingLight");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedUnicorn()
    {
        SceneManager.LoadScene("Unicorn");
        Geekplay.Instance.ShowInterstitialAd();
    }

    public void PressedFootballBall()
    {
        SceneManager.LoadScene("FootballBall");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedCheckers()
    {

        PlayerPrefs.SetInt("VsCPU", 0);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);

        Geekplay.Instance.ShowInterstitialAd();
        canvas.SetActive(false);
    }
    public void PressedGuardGame()
    {
        SceneManager.LoadScene("GuardGame");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedBowling()
    {
        SceneManager.LoadScene("Bowling");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedMathQuiz()
    {
        SceneManager.LoadScene("MathQuiz");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedPiranhaRush()
    {
        SceneManager.LoadScene("PiranhaRush");
        Geekplay.Instance.ShowInterstitialAd();
    }
}