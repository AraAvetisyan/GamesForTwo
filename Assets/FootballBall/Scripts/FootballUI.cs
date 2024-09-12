using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FootballUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private AudioSource buttonSound;
    private void Start()
    {
        Geekplay.Instance.GameReady();
    }
    public void PresedHome()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRestart()
    {
        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
      
        StartCoroutine(WaitForAdd());
    }
    public IEnumerator WaitForAdd()
    {
        yield return new WaitForSeconds(0.1f);
        if (!isSingle)
        {
            SceneManager.LoadScene("FootballBall");
        }
        else
        {
            SceneManager.LoadScene("FootballBallSingle");
        }
    }
}
