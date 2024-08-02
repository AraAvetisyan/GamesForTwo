using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChickenGameMainMenuScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private GameObject disPanel1, disPanel2, disPanel3;
    public int Index;
    [SerializeField] private AudioSource buttonSound;
    public void PressedChickenGameOne()
    {
        buttonSound.Play();
        disPanel1.SetActive(true);
        Index = 1;
        //Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedChickenGameTwo()
    {
        buttonSound.Play();

        disPanel2.SetActive(true);
        Index = 2;
        //Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedChickenGameThree()
    {
        buttonSound.Play();
        disPanel3.SetActive(true);
        Index = 3;
        //Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedHome()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
}
