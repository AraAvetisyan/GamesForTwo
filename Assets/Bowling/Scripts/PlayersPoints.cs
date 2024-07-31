using System.Collections;
using System.Collections.Generic;
using TMPro;
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

                if (PlOnePoints >= 60 && PlTwoPoints < 60)
                {
                    GameEnds = true;

                    playerOneWinPC.SetActive(true);
                    StartCoroutine(WaitToFinish());

                }
                if (PlTwoPoints >= 60 && PlOnePoints < 60)
                {
                    GameEnds = true;

                   
                    StartCoroutine(WaitToFinish());

                }
                if(PlTwoPoints > 60 && PlOnePoints > 60)
                {
                    if (PlOnePoints > PlTwoPoints)
                    {
                        GameEnds = true;

                       
                        StartCoroutine(WaitToFinish());

                    }
                    if (PlOnePoints < PlTwoPoints)
                    {
                        GameEnds = true;

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
        if (PlTwoPoints >= 60 && PlOnePoints < 60)
        {
            playerTwoWinPC.SetActive(true);
        }
        if (PlOnePoints > PlTwoPoints)
        {
            playerOneWinPC.SetActive(true);
        }
    }
}
