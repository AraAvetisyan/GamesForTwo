using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    
    public void PressedPlay()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("BowlingSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("Bowling");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
