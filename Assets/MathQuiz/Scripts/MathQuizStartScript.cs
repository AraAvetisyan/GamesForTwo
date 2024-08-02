using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

public class MathQuizStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedPlay()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("MathQuizSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("MathQuiz");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
