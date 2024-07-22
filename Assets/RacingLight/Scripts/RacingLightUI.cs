using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingLightUI : MonoBehaviour
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
            SceneManager.LoadScene("RacingLight");
        }
        if (isSingle)
        {
            SceneManager.LoadScene("RacingLightSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
