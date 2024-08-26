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
    }
    public void PressedRestart()
    {
        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
        if (!isSingle)
        {
            SceneManager.LoadScene("FootballBall");
        }
        else
        {
            SceneManager.LoadScene("FootballBallSingle");
        }
    }
}
