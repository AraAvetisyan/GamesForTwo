using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FootballUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PresedHome()
    {
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRestart()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("FootballBall");
        }
        else
        {
            SceneManager.LoadScene("FootballBallSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
