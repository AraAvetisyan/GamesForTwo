using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummoGameStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedPlay()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("SummoGameSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("SummoGame");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
