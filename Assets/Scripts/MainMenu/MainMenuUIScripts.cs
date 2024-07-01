using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIScripts : MonoBehaviour
{
    [SerializeField] private GameObject gamesForOnePanel, gamesForTwoPanel, homeMenuPanel, headerPanel;

    private void Start()
    {
        Geekplay.Instance.GameReady();
    }
    public void PressedGamesForOneButton()
    {
        gamesForOnePanel.SetActive(true);
        headerPanel.SetActive(true);
        gamesForTwoPanel.SetActive(false);
        homeMenuPanel.SetActive(false);
    }
    public void PressedGamesForTwoButton()
    {
        gamesForTwoPanel.SetActive(true);
        gamesForOnePanel.SetActive(false);
        homeMenuPanel.SetActive(false);
        headerPanel.SetActive(false);
    }
    public void PressedHomeMenuButton()
    {
        homeMenuPanel.SetActive(true);
        headerPanel.SetActive(true);
        gamesForOnePanel.SetActive(false);
        gamesForTwoPanel.SetActive(false);
    }
}
