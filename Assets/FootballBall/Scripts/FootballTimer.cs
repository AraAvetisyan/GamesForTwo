using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FootballTimer : MonoBehaviour
{
    private int seconds = 29;
    private int minutes = 1;
    private int allTime = 90;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;  
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;

    [SerializeField] private FootballPlayerTwoRun _playersRun;

    [SerializeField] private GameObject finalPanel;
    [SerializeField] private FootballBallTriggers _footballBallTriggers;
    [SerializeField] private Rigidbody2D ballRb,plOneRb,plTwoRb;
    [SerializeField] private Button plOneButton, plTwoButton;
    public bool GameEnds;
    [SerializeField] private BoxCollider2D enemyBox;
    public bool playerOneWinBool, playerTwoWinBool;
  
    private void Update()
    {
        if(_footballBallTriggers.PlayerOnePoints >= 3 || _footballBallTriggers.PlayerTwoPoints >= 3)
        {
            GameEnds = true;
            plOneRb.velocity = Vector2.zero;
            plTwoRb.velocity = Vector2.zero;
            ballRb.velocity = Vector2.zero;
            enemyBox.enabled = false;
            if (_footballBallTriggers.PlayerOnePoints > _footballBallTriggers.PlayerTwoPoints) // blue player Win
            {
                
                playerOneWinBool = true;
                StartCoroutine(WaitToFinish());
            }
            if (_footballBallTriggers.PlayerOnePoints < _footballBallTriggers.PlayerTwoPoints) //red player win
            {
                
                playerTwoWinBool = true;
                    StartCoroutine(WaitToFinish());
            }
           
        }
    }
   
    public IEnumerator WaitToFinish()
    {
        plOneButton.interactable = false;
        plTwoButton.interactable = false;

        yield return new WaitForSeconds(1f);

        finalPanel.SetActive(true);
        if (playerOneWinBool)
        {
            playerOneWinPC.SetActive(true);
        }
        if(playerTwoWinBool)
        {
            playerTwoWinPC.SetActive(true);
        }
    }
}
