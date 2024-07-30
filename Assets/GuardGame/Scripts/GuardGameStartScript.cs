using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGameStartScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;

    private bool isMobile;
    [SerializeField] private GameObject startPanel;
    public static Action<int> StartGuardGame;
    [SerializeField] private GameObject joysticPlOne, joysticPlTwo;
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
        StartGuardGame?.Invoke(1);
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
