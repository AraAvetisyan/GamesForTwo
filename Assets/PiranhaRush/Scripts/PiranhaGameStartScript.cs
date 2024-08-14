using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiranhaGameStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedPlay()
    {
        Destroy(MainMenuAudioController.Instance.Music);
        buttonSound.Play();
        if (isSingle)
        {
            SceneManager.LoadScene("PiranhaRushSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("PiranhaRush");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
