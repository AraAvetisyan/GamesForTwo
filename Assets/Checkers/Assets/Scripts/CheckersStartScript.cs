using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckersStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedPlay()
    {
        Destroy(MainMenuAudioController.Instance.Music);
        buttonSound.Play();
        if (isSingle)
        {
            PlayerPrefs.SetInt("VsCPU",  1);
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            PlayerPrefs.SetInt("VsCPU", 0);
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
