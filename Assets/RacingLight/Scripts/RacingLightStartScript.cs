using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacingLightStartScript : MonoBehaviour
{
    public static Action<int> RacingLightStarts;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private Button plTwoButton;
   
    public void PressedPlay()
    {
        RacingLightStarts?.Invoke(1);
        startPanel.SetActive(false);
        plTwoButton.interactable = true;
    }
}
