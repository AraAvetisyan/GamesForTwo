using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiranhaGameStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedPlay()
    {
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
