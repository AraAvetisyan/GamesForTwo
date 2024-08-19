using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingUI : MonoBehaviour
{
    [SerializeField] bool isSingle;
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
            SceneManager.LoadScene("Bowling");
        }
        else
        {
            SceneManager.LoadScene("BowlingSnigle");
        }
    }
}
