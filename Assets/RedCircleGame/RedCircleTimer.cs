using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RedCircleTimer : MonoBehaviour
{
    private int seconds = 30;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private RedCirclePlayerOneScript _redCirclePlayerOneScript;
    [SerializeField] private RedCirclePlayerTwoScript _redCirclePlayerTwoScript;
    [SerializeField] private CircularMotion playerOneMove;
    [SerializeField] private CircularMotion playerTwoMove;
    [SerializeField] private GameObject playerOneWin, playerTwoWin;
    [SerializeField] private Button playerOneButton, playerTwoButton;
    public bool PlOneCantPlay, PlTwoCantPlay;
    private void Start()
    {
        StartCoroutine(Timer());
    }
    private void Update()
    {
        if (seconds <= 0)
        {
            playerOneMove.Speed = 0;
            playerTwoMove.Speed = 0;
        }
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        if (seconds > 0)
        {

            seconds--;
            if (seconds >= 10)
            {
                timerText.text = seconds.ToString();
            }
            else
            {
                timerText.text = "0" + seconds.ToString();
            }
            StartCoroutine(Timer());
        }
        if(seconds <= 0)
        {
            finishPanel.SetActive(true);
            playerOneMove.Speed = 0;
            playerTwoMove.Speed = 0;
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;
            PlOneCantPlay = true;
            PlTwoCantPlay = true;
            if (_redCirclePlayerOneScript.Points > _redCirclePlayerTwoScript.Points)
            {
                playerOneWin.SetActive(true);
            }
            if(_redCirclePlayerTwoScript.Points > _redCirclePlayerOneScript.Points)
            {
                playerTwoWin.SetActive(true);
            }
            if(_redCirclePlayerTwoScript.Points == _redCirclePlayerOneScript.Points)
            {
                playerOneWin.SetActive(true);
                playerTwoWin.SetActive(true);
            }
        }
    }
    
}
