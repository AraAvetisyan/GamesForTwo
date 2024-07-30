using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallStartScript : MonoBehaviour
{
    public static Action<int> StartGreenBallGame;
    [SerializeField] private GameObject startPanel; 
    public void PressedPlay()
    {
        StartGreenBallGame?.Invoke(1);
        startPanel.SetActive(false);
    }
}
