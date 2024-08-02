using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenBallStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedPlay()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("GreenBallSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("GreenBall");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
