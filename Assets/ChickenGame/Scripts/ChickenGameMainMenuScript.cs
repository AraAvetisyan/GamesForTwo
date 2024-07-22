using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameMainMenuScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedChickenGameOne()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("ChickenGameOne");
        }
        else
        {

            SceneManager.LoadScene("ChickenGameOneSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedChickenGameTwo()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("ChickenGameTwo");
        }
        else
        {

            SceneManager.LoadScene("ChickenGameTwoSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedChickenGameThree()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("ChickenGameThree");
        }
        else
        {

            SceneManager.LoadScene("ChickenGameThreeSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
}
