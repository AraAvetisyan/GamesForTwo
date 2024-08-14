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
        Geekplay.Instance.ShowInterstitialAd();
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
