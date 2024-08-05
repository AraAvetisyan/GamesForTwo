using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayersPoints : MonoBehaviour
{
    [SerializeField] private DragItemsPlOne _playerOneDrag;
    [SerializeField] private DragItemsPlTwo _playerTwoDrag;
    [SerializeField] private int count;
    public int PlOnePoints, PlTwoPoints;
    [SerializeField] private TextMeshProUGUI playerOnePointsText, playerTwoPointsText;
    [SerializeField] private GameObject finalPanel,  playerTwoWinPC,  playerOneWinPC;
    public bool StrikePlayerOne, StrikePlayerTwo;
    
    public bool GameEnds;

    private bool playerOneWin, playerTwoWin;
    [SerializeField] private GameObject playerOneObject, playerTwoObject;
    private void Start()
    {
       
    }
    private void OnEnable()
    {
        PinScriptPlOne.Pin += AddPoints;
        PinScriptPlTwo.Pin += AddPoints;
    }
    private void OnDisable()
    {
        PinScriptPlOne.Pin -= AddPoints;
        PinScriptPlTwo.Pin -= AddPoints;
    }
    public void AddPoints(int pinCount)
    {
        count += pinCount;
      
    }
    private void Update()
    {
        if (_playerOneDrag.PlayerOneTurn)
        {
            if (_playerOneDrag.AddPoints)
            {
                _playerOneDrag.AddPoints = false;
                if (count == 10)
                {
                    PlOnePoints += 12;
                    StrikePlayerOne = true;
                }
                if (count < 10)
                {
                    PlOnePoints += count;
                }
                playerOnePointsText.text = PlOnePoints.ToString();
                count = 0;
            }
        }
        if(_playerTwoDrag.PlayerTwoTurn)
        {
            if (_playerTwoDrag.AddPoints)
            {
                _playerTwoDrag.AddPoints = false;
                if (count == 10)
                {
                    PlTwoPoints += 12;
                    StrikePlayerTwo = true;
                }
                if (count < 10)
                {
                    PlTwoPoints += count;
                }
                playerTwoPointsText.text = PlTwoPoints.ToString();
                count = 0;
            }
        }

        if (!GameEnds)
        {
            if(_playerOneDrag.GameCount == _playerTwoDrag.GameCount)
            {

                if (PlOnePoints >= 60 && PlTwoPoints < 60) // playerOneWin
                {
                    GameEnds = true;
                    playerOneWin = true;
                    playerOneObject.SetActive(false);
                    playerTwoObject.SetActive(false);

                    StartCoroutine(WaitToFinish());
                }
                if (PlTwoPoints >= 60 && PlOnePoints < 60) // playerTwoWin
                {
                    GameEnds = true;
                    playerTwoWin = true;
                    playerOneObject.SetActive(false);
                    playerTwoObject.SetActive(false);


                    StartCoroutine(WaitToFinish());

                }
                if(PlTwoPoints > 60 && PlOnePoints > 60)
                {
                    if (PlOnePoints > PlTwoPoints) // playerOne Win
                    {
                        GameEnds = true;
                        playerOneWin = true;
                        playerOneObject.SetActive(false);
                        playerTwoObject.SetActive(false);


                        StartCoroutine(WaitToFinish());

                    }
                    if (PlOnePoints < PlTwoPoints) // PlayerTwoWin
                    {
                        GameEnds = true;
                        playerTwoWin = true;
                        playerOneObject.SetActive(false);
                        playerTwoObject.SetActive(false);
                        StartCoroutine(WaitToFinish());

                    }
                }
                
            }
        }
    }
    public IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1f);
        finalPanel.SetActive(true);
        if (playerTwoWin)
        {
            playerTwoWinPC.SetActive(true);
        }
        if (playerOneWin)
        {
            playerOneWinPC.SetActive(true);
        }
    }
}
