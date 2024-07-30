using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCircleStartScript : MonoBehaviour
{
    public static Action<int> RedCircleGameStarts;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private Button plOneButton, plTwoButton;
    [SerializeField] private bool isSingle;
    public void PressedPlay()
    {
        RedCircleGameStarts?.Invoke(1);
        startPanel.SetActive(false);
        if (!isSingle)
        {
            plOneButton.interactable = true;
            plTwoButton.interactable = true;
        }
        if (isSingle)
        {
            plTwoButton.interactable = true;
        }
    }
}
