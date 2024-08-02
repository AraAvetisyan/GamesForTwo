using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIScripts : MonoBehaviour
{
    [SerializeField] private GameObject gamesForOnePanel, gamesForTwoPanel, homeMenuPanel, headerPanel;
    [SerializeField] private AudioSource buttonSound;

    private void Start()
    {
        Geekplay.Instance.GameReady();
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedGamesForOneButton()
    {
        buttonSound.Play();
        gamesForOnePanel.SetActive(true);
        headerPanel.SetActive(true);
        gamesForTwoPanel.SetActive(false);
        homeMenuPanel.SetActive(false);
    }
    public void PressedGamesForTwoButton()
    {
        buttonSound.Play(); 
        gamesForTwoPanel.SetActive(true);
        gamesForOnePanel.SetActive(false);
        homeMenuPanel.SetActive(false);
        headerPanel.SetActive(false);
    }
    public void PressedHomeMenuButton()
    {
        buttonSound.Play();
        homeMenuPanel.SetActive(true);
        headerPanel.SetActive(true);
        gamesForOnePanel.SetActive(false);
        gamesForTwoPanel.SetActive(false);
    }
}
