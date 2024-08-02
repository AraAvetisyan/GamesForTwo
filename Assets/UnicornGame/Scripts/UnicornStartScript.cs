using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnicornStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedPlay()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("UnicornSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("Unicorn");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
