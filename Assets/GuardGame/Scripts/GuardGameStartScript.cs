using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardGameStartScript : MonoBehaviour
{

    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;

    public void PressedPlay()
    {
        Destroy(MainMenuAudioController.Instance.Music);
        buttonSound.Play();
        if (isSingle)
        {
            SceneManager.LoadScene("GuardGameSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("GuardGame");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
