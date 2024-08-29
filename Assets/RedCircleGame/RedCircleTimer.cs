
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


    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject playerOneDrawPC;

    [SerializeField] private Button playerOneButton, playerTwoButton;
    public bool PlOneCantPlay, PlTwoCantPlay;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource end;
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
            if(seconds > 0 && seconds < 10)
            {
                timerText.text = "0" + seconds.ToString();
            }
            StartCoroutine(Timer());
        }
        if (seconds <= 0)
        {
            timerText.text = "0";
            playerOneMove.Speed = 0;
            playerTwoMove.Speed = 0;
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;
            PlOneCantPlay = true;
            PlTwoCantPlay = true;
            StartCoroutine(WaitToFinish());
        }
    }
    public IEnumerator WaitToFinish()
    {
        music.Stop();
        yield return new WaitForSeconds(1f);
        end.Play();
        finishPanel.SetActive(true);
        if (_redCirclePlayerOneScript.Points > _redCirclePlayerTwoScript.Points)
        {

            playerOneWinPC.SetActive(true);

        }
        if (_redCirclePlayerTwoScript.Points > _redCirclePlayerOneScript.Points)
        {

            playerTwoWinPC.SetActive(true);

        }
        if (_redCirclePlayerTwoScript.Points == _redCirclePlayerOneScript.Points)
        {

            playerOneDrawPC.SetActive(true);

        }
    }
}
