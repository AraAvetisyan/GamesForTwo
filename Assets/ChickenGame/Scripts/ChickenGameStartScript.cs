using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGameStartScript : MonoBehaviour
{
    public static Action<int> ChickenGameStart;
    [SerializeField] private GameObject startPanel;
    public void PressedPlay()
    {
        ChickenGameStart?.Invoke(1);
        startPanel.SetActive(false);
    }
}
