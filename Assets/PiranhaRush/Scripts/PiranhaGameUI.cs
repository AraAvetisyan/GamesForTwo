using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiranhaGameUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;

    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRest()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("PiranhaRushSingle");
        }
        else
        {
            SceneManager.LoadScene("PiranhaRush");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
