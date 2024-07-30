using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGameStartScript : MonoBehaviour
{
    public static Action<int> TimerGameStart;
    [SerializeField] private GameObject startPanel;
    public void PressedPlay()
    {
        TimerGameStart?.Invoke(1);
        startPanel.SetActive(false);
    }

}
