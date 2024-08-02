using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameUIController : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private AudioSource buttonSound;

    public void PressedHomeButton()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedChickenGameOneRestart()
    {
        buttonSound.Play();
        if (sceneIndex == 1)
        {
            SceneManager.LoadScene("ChickenGameOne");
        }
        if (sceneIndex == 2)
        {
            SceneManager.LoadScene("ChickenGameTwo");
        }
        if(sceneIndex == 3)
        {
            SceneManager.LoadScene("ChickenGameThree");
        }
        if (sceneIndex == 4)
        {
            SceneManager.LoadScene("ChickenGameOneSingle");
        }
        if (sceneIndex == 5)
        {
            SceneManager.LoadScene("ChickenGameTwoSingle");
        }
        if (sceneIndex == 6)
        {
            SceneManager.LoadScene("ChickenGameThreeSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
