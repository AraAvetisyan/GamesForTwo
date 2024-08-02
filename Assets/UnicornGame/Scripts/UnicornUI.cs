using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnicornUI : MonoBehaviour
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
            SceneManager.LoadScene("Unicorn");
        }
        else
        {
            SceneManager.LoadScene("UnicornSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
