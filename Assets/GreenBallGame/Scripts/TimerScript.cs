
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static Action<bool> GameEnds;
    private int seconds = 29;
    private int minutes = 1;
    private int allTime = 90;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GreenBallGameUIController _greenBallGameUIController;
    [SerializeField] private int index;
    private void Start()
    {
        StartCoroutine(Timer());
        if (index == 1)
        {
            if (!_greenBallGameUIController.IsMobile || _greenBallGameUIController.IsSingle)
            {
                timerText.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (_greenBallGameUIController.IsMobile && !_greenBallGameUIController.IsSingle)
            {
                timerText.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }

    }
    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        if (seconds < 0)
        {
            seconds = 0;
        }
        if (seconds >= 10)
        {
            timerText.text = minutes.ToString() + ":" + seconds.ToString();
        }
        else
        {
            timerText.text = minutes.ToString() + ":0" + seconds.ToString();
        }

        allTime--;
        seconds--;
        if (allTime > 0)
        {
            StartCoroutine(Timer());
        }
        if (seconds == 0 && minutes == 1)
        {
            minutes--;
            seconds = 59;
        }
        if (allTime == 0)
        {
            GameEnds?.Invoke(true);
        }
    }
}
