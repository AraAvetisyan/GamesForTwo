using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnicornUI : MonoBehaviour
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
            SceneManager.LoadScene("Unicorn");
        }
        else
        {
            SceneManager.LoadScene("UnicornSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
