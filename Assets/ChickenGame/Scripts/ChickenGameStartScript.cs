using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private ChickenGameMainMenuScript _chickenGameMainMenuScript;
    public void PressedPlay()
    {
        Destroy(MainMenuAudioController.Instance.Music);
        if (isSingle)
        {
            if (_chickenGameMainMenuScript.Index == 1)
            {
                SceneManager.LoadScene("ChickenGameOneSingle");
            }
            if (_chickenGameMainMenuScript.Index == 2)
            {
                SceneManager.LoadScene("ChickenGameTwoSingle");
            }
            if (_chickenGameMainMenuScript.Index == 3)
            {
                SceneManager.LoadScene("ChickenGameThreeSingle");
            }
        }
        if (!isSingle)
        {
            if (_chickenGameMainMenuScript.Index == 1)
            {
                SceneManager.LoadScene("ChickenGameOne");
            }
            if (_chickenGameMainMenuScript.Index == 2)
            {
                SceneManager.LoadScene("ChickenGameTwo");
            }
            if (_chickenGameMainMenuScript.Index == 3)
            {
                SceneManager.LoadScene("ChickenGameThree");
            }
        }

        Geekplay.Instance.ShowInterstitialAd();
    }
}
