using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingUI : MonoBehaviour
{
    [SerializeField] bool isSingle;

    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRest()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("Bowling");
        }
        else
        {
            SceneManager.LoadScene("BowlingSnigle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
