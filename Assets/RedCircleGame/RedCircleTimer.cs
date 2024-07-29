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

    [SerializeField] private RedCircleUIController _redCircleUIController;

    //[SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    //[SerializeField] private GameObject playerOneDrawMobile, playerTwoDrawMobile;

    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject draw;

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
           
            StartCoroutine(WaitToFinish());
           
        }
    }
    public IEnumerator WaitToFinish()
    {
        playerOneMove.Speed = 0;
        playerTwoMove.Speed = 0;
        playerOneButton.interactable = false;
        playerTwoButton.interactable = false;
        PlOneCantPlay = true;
        PlTwoCantPlay = true;
        yield return new WaitForSeconds(1.5f);
        finishPanel.SetActive(true);
        if (_redCirclePlayerOneScript.Points > _redCirclePlayerTwoScript.Points)
        {
            //if (_redCircleUIController.IsMobile && !_redCircleUIController.IsSingle)
            //{
            //    // playerOneWinMobile.SetActive(true);
            //}
            //if (!_redCircleUIController.IsMobile || _redCircleUIController.IsSingle)
            //{
            //    // 
            //}
            playerOneWinPC.SetActive(true);
        }
        if (_redCirclePlayerTwoScript.Points > _redCirclePlayerOneScript.Points)
        {
            //if (_redCircleUIController.IsMobile && !_redCircleUIController.IsSingle)
            //{
            //    // playerTwoWinMobile.SetActive(true);
            //}
            //if (!_redCircleUIController.IsMobile || _redCircleUIController.IsSingle)
            //{

            //}
            playerTwoWinPC.SetActive(true);
        }
        if (_redCirclePlayerTwoScript.Points == _redCirclePlayerOneScript.Points)
        {
            //if (_redCircleUIController.IsMobile && !_redCircleUIController.IsSingle)
            //{
            //    //  playerOneDrawMobile.SetActive(true);
            //    //playerTwoDrawMobile.SetActive(true);
            //}
            //if (!_redCircleUIController.IsMobile || _redCircleUIController.IsSingle)
            //{

            //    //playerTwoDrawPC.SetActive(true);
            //}
            draw.SetActive(true);
        }
    }
}
