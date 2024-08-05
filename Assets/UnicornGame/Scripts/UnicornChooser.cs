
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnicornChooser : MonoBehaviour
{
    [SerializeField] private PlayerOneChooser _playerOneChooser;
    [SerializeField] private PlayerTwoChooser _playerTwoChooser;
    private int headInt, hairInt, cornInt, faceInt, eyesInt;
    [SerializeField] private GameObject[] plOneHeadMobile, plOneHairMobile, plOneCornMobile, plOneFaceMobile, plOneEyesMobile;
    [SerializeField] private GameObject[] plOneHeadPC, plOneHairPC, plOneCornPC, plOneFacePC, plOneEyesPC;
    [SerializeField] private GameObject[] plTwoHead, plTwoHair, plTwoCorn, plTwoFace, plTwoEyes;

    [SerializeField] private TextMeshProUGUI timertext;
    [SerializeField] private TextMeshProUGUI secondsText;
    [SerializeField] private GameObject secondsBG;
    [SerializeField] private GameObject TimerToCloseBG;
    private int timer;
    public bool Closed;
    private int counter;
    private int seconds;

    [SerializeField] TextMeshProUGUI playerOnePointsText, playerTwoPointsText;
    private int playerOnePoints, playerTwoPoints;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject playerOneDrawPC;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject plOneScoreBG, plTwoScoreBG;
    [SerializeField] private AudioSource music;
    void Start()
    {
        seconds = 30;
        headInt = Random.Range(0, 4);
        hairInt = Random.Range(0, 4);
        cornInt = Random.Range(0, 5);
        faceInt = Random.Range(0, 4);
        eyesInt = Random.Range(0, 5);
        plTwoHead[headInt].SetActive(true);
        plTwoHair[hairInt].SetActive(true);
        plTwoCorn[cornInt].SetActive(true);
        plTwoFace[faceInt].SetActive(true);
        plTwoEyes[eyesInt].SetActive(true);
        if (_playerTwoChooser.IsMobile && !_playerTwoChooser.IsSingle)
        {
            playerOnePointsText.transform.rotation = Quaternion.Euler(0, 0, 180);
            plOneScoreBG.SetActive(false);
            plTwoScoreBG.SetActive(false);
            plOneHeadMobile[headInt].SetActive(true);
            plOneHairMobile[hairInt].SetActive(true);
            plOneCornMobile[cornInt].SetActive(true);
            plOneFaceMobile[faceInt].SetActive(true);
            plOneEyesMobile[eyesInt].SetActive(true);
        }
        if (!_playerTwoChooser.IsMobile || _playerTwoChooser.IsSingle)
        {

            playerOnePointsText.transform.rotation = Quaternion.Euler(0, 0, 0);
            plOneScoreBG.SetActive(false);
            plTwoScoreBG.SetActive(false);
            plOneHeadPC[headInt].SetActive(true);
            plOneHairPC[hairInt].SetActive(true);
            plOneCornPC[cornInt].SetActive(true);
            plOneFacePC[faceInt].SetActive(true);
            plOneEyesPC[eyesInt].SetActive(true);
        }
        StartCoroutine(WaitToClose());
    }

    private void Update()
    {
        if (_playerOneChooser.PlayerOneEnds && _playerTwoChooser.PlayerTwoEnds && counter == 0)
        {
            counter = 1;
            seconds = 0;
        }
        if (counter == 1)
        {
            counter = 2;
            if (_playerOneChooser.PlayerOneEnds && counter == 2)
            {
                if (_playerOneChooser.HeadInt == headInt)
                {
                    playerOnePoints += 5;
                }
                if (_playerOneChooser.HairInt == hairInt)
                {
                    playerOnePoints += 5;
                }
                if (_playerOneChooser.CornInt == cornInt)
                {
                    playerOnePoints += 5;
                }
                if (_playerOneChooser.FaceInt == faceInt)
                {
                    playerOnePoints += 5;
                }
                if (_playerOneChooser.EyesInt == eyesInt)
                {
                    playerOnePoints += 5;
                }
            }
            if (_playerTwoChooser.PlayerTwoEnds && counter == 2)
            {
                if (_playerTwoChooser.HeadInt == headInt)
                {
                    playerTwoPoints += 5;
                }
                if (_playerTwoChooser.HairInt == hairInt)
                {
                    playerTwoPoints += 5;
                }
                if (_playerTwoChooser.CornInt == cornInt)
                {
                    playerTwoPoints += 5;
                }
                if (_playerTwoChooser.FaceInt == faceInt)
                {
                    playerTwoPoints += 5;
                }
                if (_playerTwoChooser.EyesInt == eyesInt)
                {
                    playerTwoPoints += 5;
                }
            }
            counter = 3;

            plOneScoreBG.SetActive(true);
            plTwoScoreBG.SetActive(true);
            playerOnePointsText.text = playerOnePoints.ToString();
            playerTwoPointsText.text = playerTwoPoints.ToString();

            StartCoroutine(WaitToFinish());

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
        secondsText.text = seconds.ToString();
        if (seconds >= 0)
        {
            StartCoroutine(Timer());
        }
        if (!_playerOneChooser.PlayerOneEnds || !_playerTwoChooser.PlayerTwoEnds)
        {
            if (seconds == 0)
            {
                counter = 1;
                secondsText.text = "0";
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

        timertext.text = "";
        TimerToCloseBG.SetActive(false);
        secondsBG.SetActive(true);
        StartCoroutine(Timer());
        plOneHeadMobile[headInt].SetActive(false);
        plTwoHead[headInt].SetActive(false);
        plOneHairMobile[hairInt].SetActive(false);
        plTwoHair[hairInt].SetActive(false);
        plOneCornMobile[cornInt].SetActive(false);
        plTwoCorn[cornInt].SetActive(false);
        plOneFaceMobile[faceInt].SetActive(false);
        plTwoFace[faceInt].SetActive(false);
        plOneEyesMobile[eyesInt].SetActive(false);
        plTwoEyes[eyesInt].SetActive(false);
        plOneHeadPC[headInt].SetActive(false);
        plOneHairPC[hairInt].SetActive(false);
        plOneCornPC[cornInt].SetActive(false);
        plOneFacePC[faceInt].SetActive(false);
        plOneEyesPC[eyesInt].SetActive(false);
        Closed = true;
    }
    public IEnumerator WaitToFinish()
    {
        music.Stop();
        yield return new WaitForSeconds(2f);
        finalPanel.SetActive(true);
        if (playerOnePoints > playerTwoPoints)
        {

            playerOneWinPC.SetActive(true);


        }
        if (playerOnePoints < playerTwoPoints)
        {
            playerTwoWinPC.SetActive(true);


        }
        if (playerOnePoints == playerTwoPoints)
        {

            playerOneDrawPC.SetActive(true);

        }
    }
}
