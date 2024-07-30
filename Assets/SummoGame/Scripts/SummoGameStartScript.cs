using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoGameStartScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bc2D;
    [SerializeField] private GameObject startPanel;
    public static Action<int> SummoGameStarts;
    public void PressedPlay()
    {
        SummoGameStarts?.Invoke(1);
        bc2D.enabled = true;
        startPanel.SetActive(false);
    }
}
