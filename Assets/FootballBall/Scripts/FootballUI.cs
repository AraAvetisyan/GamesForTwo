using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FootballUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PresedHome()
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
            SceneManager.LoadScene("FootballBall");
        }
        else
        {
            SceneManager.LoadScene("FootballBallSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
