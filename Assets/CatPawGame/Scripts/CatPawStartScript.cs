using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatPawStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedStart()
    {
        buttonSound.Play();
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
