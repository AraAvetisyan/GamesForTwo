using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatPawStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    
    public void PressedStart()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("CatPawSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("CatPaw");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
