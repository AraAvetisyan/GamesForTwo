using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoGameStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedPlay()
    {
        buttonSound.Play();
        if (isSingle)
        {
            SceneManager.LoadScene("DinosaurGameSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("DinosaurGame");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
