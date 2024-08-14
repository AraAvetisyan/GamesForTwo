using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FootballBallStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    public void PressedPlay()
    {
        Destroy(MainMenuAudioController.Instance.Music);
        buttonSound.Play();
        if (isSingle)
        {
            SceneManager.LoadScene("FootballBallSingle");
            Geekplay.Instance.ShowInterstitialAd();
        }
        else
        {
            SceneManager.LoadScene("FootballBall");
            Geekplay.Instance.ShowInterstitialAd();
        }
    }
}
