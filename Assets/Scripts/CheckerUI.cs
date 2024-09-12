using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckerUI : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    public void PressedHomeButton()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
        StartCoroutine(WaitForAdd());
    }
    public IEnumerator WaitForAdd()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
