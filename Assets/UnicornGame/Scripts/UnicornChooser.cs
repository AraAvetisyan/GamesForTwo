using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnicornChooser : MonoBehaviour
{
    [SerializeField] private PlayerOneChooser _playerOneChooser;
    [SerializeField] private PlayerTwoChooser _playerTwoChooser;
    private int headInt, hairInt, cornInt, faceInt, eyesInt;
    [SerializeField] private GameObject[] plOneHead, plOneHair, plOneCorn, plOneFace, plOneEyes;
    [SerializeField] private GameObject[] plTwoHead, plTwoHair, plTwoCorn, plTwoFace, plTwoEyes;
    [SerializeField] private TextMeshProUGUI timertext;
    private int timer;
    public bool Closed;
    private int counter;
    private int seconds;

    [SerializeField] TextMeshProUGUI playerOnePointsText, playerTwoPointsText;
    private int playerOnePoints, playerTwoPoints;
    [SerializeField] private GameObject playerOneWin, playerTwoWin;
    [SerializeField] private GameObject playerOneDraw, playerTwoDraw;
    [SerializeField] private GameObject finalPanel;
    void Start()
    {
        seconds = 30;
        headInt = Random.Range(0, 4);
        hairInt = Random.Range(0, 4);
        cornInt = Random.Range(0, 5);
        faceInt = Random.Range(0, 5);
        eyesInt = Random.Range(0, 5);
        plOneHead[headInt].SetActive(true);
        plTwoHead[headInt].SetActive(true);
        plOneHair[hairInt].SetActive(true);
        plTwoHair[hairInt].SetActive(true);
        plOneCorn[cornInt].SetActive(true);
        plTwoCorn[cornInt].SetActive(true);
        plOneFace[faceInt].SetActive(true);
        plTwoFace[faceInt].SetActive(true);
        plOneEyes[eyesInt].SetActive(true);
        plTwoEyes[eyesInt].SetActive(true);
        StartCoroutine(WaitToClose());
    }

    private void Update()
    {
        if(_playerOneChooser.PlayerOneEnds && _playerTwoChooser.PlayerTwoEnds && counter == 0)
        {
            counter = 1;
            seconds = 0;
        }
        if(counter == 1) 
        {
            counter = 2;
            if (_playerOneChooser.PlayerOneEnds && counter == 2)
            {
                if(_playerOneChooser.HeadInt == headInt)
                {
                    playerOnePoints += 5;
                }
                if(_playerOneChooser.HairInt == hairInt)
                {
                    playerOnePoints += 5;
                }
                if (_playerOneChooser.CornInt == cornInt)
                {
                    playerOnePoints += 5;
                }
                if(_playerOneChooser.FaceInt == faceInt)
                {
                    playerOnePoints += 5;
                }
                if(_playerOneChooser.EyesInt == eyesInt)
                {
                    playerOnePoints += 5;
                }
            }
            if (_playerTwoChooser.PlayerTwoEnds && counter == 2)
            {
                if(_playerTwoChooser.HeadInt == headInt)
                {
                    playerTwoPoints += 5;
                }
                if (_playerTwoChooser.HairInt == hairInt)
                {
                    playerTwoPoints += 5;
                }
                if(_playerTwoChooser.CornInt == cornInt)
                {
                    playerTwoPoints += 5;
                }
                if(_playerTwoChooser.FaceInt == faceInt)
                {
                    playerTwoPoints += 5;
                }
                if (_playerTwoChooser.EyesInt == eyesInt)
                {
                    playerTwoPoints += 5;
                }
            }
            counter = 3;
            playerOnePointsText.text = playerOnePoints.ToString();
            playerTwoPointsText.text = playerTwoPoints.ToString();
            if (playerOnePoints > playerTwoPoints)
            {
                playerOneWin.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
            if (playerOnePoints < playerTwoPoints)
            {
                playerTwoWin.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
            if (playerOnePoints == playerTwoPoints)
            {
                playerOneDraw.SetActive(true);
                playerTwoDraw.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
        }
    }
    public IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        seconds--;
        if (seconds <= 0)
        {
            seconds = 0;
        }
        timertext.text = seconds.ToString();
        if (seconds >= 0)
        {
            StartCoroutine(Timer());
        }
        if (!_playerOneChooser.PlayerOneEnds || !_playerTwoChooser.PlayerTwoEnds)
        {
            if (seconds == 0)
            {
                counter = 1;
                timertext.text = "";
            }
        }
    }
    public IEnumerator WaitToClose()
    {
        timer = 5;
        timertext.text = timer.ToString();
        yield return new WaitForSecondsRealtime(1);
        timer = 4;
        timertext.text = timer.ToString();
        yield return new WaitForSecondsRealtime(1);
        timer = 3;
        timertext.text = timer.ToString();
        yield return new WaitForSecondsRealtime(1);
        timer = 2;
        timertext.text = timer.ToString();
        yield return new WaitForSecondsRealtime(1);
        timer = 1;
        timertext.text = timer.ToString();
        yield return new WaitForSecondsRealtime(1);

        StartCoroutine(Timer());
        timertext.text = "";
        plOneHead[headInt].SetActive(false);
        plTwoHead[headInt].SetActive(false);
        plOneHair[hairInt].SetActive(false);
        plTwoHair[hairInt].SetActive(false);
        plOneCorn[cornInt].SetActive(false);
        plTwoCorn[cornInt].SetActive(false);
        plOneFace[faceInt].SetActive(false);
        plTwoFace[faceInt].SetActive(false);
        plOneEyes[eyesInt].SetActive(false);
        plTwoEyes[eyesInt].SetActive(false);
        Closed = true;
    }
    public IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
