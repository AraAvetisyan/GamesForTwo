using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedHome()
    {
        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
        if (!isSingle)
        {
            SceneManager.LoadScene("GuardGame");
        }
        else
        {
            SceneManager.LoadScene("GuardGameSingle");
        }
    }
}
