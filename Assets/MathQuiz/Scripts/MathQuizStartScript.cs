using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

public class MathQuizStartScript : MonoBehaviour
{
    public static Action<int> StartMathQuizGame;
    [SerializeField] private Button plOneButtonOne, plOneBuutonTwo, plOneBuutonThree;
    [SerializeField] private Button plTwoButtonOne, plTwoBuutonTwo, plTwoBuutonThree;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private bool isSingle;
    public void PressedPlay()
    {
        StartMathQuizGame?.Invoke(1);
        if (!isSingle)
        {
            plOneButtonOne.interactable = true;
            plOneBuutonTwo.interactable = true;
            plOneBuutonThree.interactable = true;
            plTwoButtonOne.interactable = true;
            plTwoBuutonTwo.interactable = true;
            plTwoBuutonThree.interactable = true;
        }
        if (isSingle)
        {
            plOneButtonOne.interactable = true;
            plOneBuutonTwo.interactable = true;
            plOneBuutonThree.interactable = true;
        }
        startPanel.SetActive(false);
    }
}
