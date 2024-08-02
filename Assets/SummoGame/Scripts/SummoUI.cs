using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummoUI : MonoBehaviour
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
            SceneManager.LoadScene("SummoGame");
        }
        else
        {
            SceneManager.LoadScene("SummoGameSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }

}
