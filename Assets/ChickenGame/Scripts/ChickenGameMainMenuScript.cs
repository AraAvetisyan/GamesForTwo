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
    public void PressedChickenGameOne()
    {
        disPanel1.SetActive(true);
        Index = 1;
        //Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedChickenGameTwo()
    {

        disPanel2.SetActive(true);
        Index = 2;
        //Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedChickenGameThree()
    {
        disPanel3.SetActive(true);
        Index = 3;
        //Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
}
