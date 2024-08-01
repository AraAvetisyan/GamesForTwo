using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
<<<<<<< HEAD
    [SerializeField] private ChickenGameMainMenuScript _chickenGameMainMenuScript;
=======
>>>>>>> 7a7a933a908c99bb3e8b7bb4f29ca83d2e33b166
    public void PressedPlay()
    {
        if (isSingle)
        {
<<<<<<< HEAD
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
=======
            SceneManager.LoadScene("ChickenGameSingle");
        }
        else
        {
            SceneManager.LoadScene("ChickenGame");
        }
>>>>>>> 7a7a933a908c99bb3e8b7bb4f29ca83d2e33b166
    }
}
