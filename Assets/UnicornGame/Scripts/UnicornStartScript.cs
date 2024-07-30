using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornStartScript : MonoBehaviour
{
    public static Action<int> UnicornGameStart;
    [SerializeField] private GameObject startPanel;
    public void PressedPlay()
    {
        UnicornGameStart?.Invoke(1);
        startPanel.SetActive(false);
    }
}
