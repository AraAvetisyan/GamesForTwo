using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRest()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("GuardGame");
        }
        else
        {
            SceneManager.LoadScene("GuardGameSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
