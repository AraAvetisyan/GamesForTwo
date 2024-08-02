using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingLightUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedHome()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRest()
    {
        buttonSound.Play();
        if (!isSingle)
        {
            SceneManager.LoadScene("RacingLight");
        }
        if (isSingle)
        {
            SceneManager.LoadScene("RacingLightSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
