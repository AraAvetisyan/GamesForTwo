using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckerUI : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    public void PressedHomeButton()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRest()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        Geekplay.Instance.ShowInterstitialAd();
    }
}
