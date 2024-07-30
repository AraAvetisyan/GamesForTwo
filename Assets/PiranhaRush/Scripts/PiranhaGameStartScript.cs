using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaGameStartScript : MonoBehaviour
{
    public static Action<int> StartPiranhaGame;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject joysticPlOne, joysticPlTwo;
    private bool isMobile;
    [SerializeField] private bool isSingle;
    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;

        }
    }

    public void PressedPlay()
    {
        StartPiranhaGame?.Invoke(1);
        startPanel.SetActive(false);
        if (!isSingle && isMobile)
        {
            joysticPlOne.SetActive(true);
            joysticPlTwo.SetActive(true);
        }
        if (isSingle && isMobile)
        {
            joysticPlOne.SetActive(true);
        }
    }
}
