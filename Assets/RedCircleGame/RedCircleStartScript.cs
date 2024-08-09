using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RedCircleStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedPlay()
    {
        Destroy(MainMenuAudioController.Instance.Music);
        buttonSound.Play();
        if (isSingle)
        {
            SceneManager.LoadScene("RedCircleSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("RedCircle");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
