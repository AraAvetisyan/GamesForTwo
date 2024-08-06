using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummoTriggers : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private Transform playerOneStartPos, playerTwoStartPos;
    [SerializeField] private GameObject playerOneObject, playerTwoObject;
    public int PlayerOnePoints, PlayerTwoPoints;
    [SerializeField] private TextMeshProUGUI playerOnePointsText, playerTwoPointsText;
    [SerializeField] private SummoGameScriptPlOne _summoGameScriptPlOne;
    [SerializeField] private SummoGameScriptPlTwo  _summoGameScriptPlTwo;
    [SerializeField] private SummoTriggers _plOneSummoTrigger, _plTwoSummoTrigger;

    [SerializeField] private Button playerOneButton, playerTwoButton;

//    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject finalPanel;
    private bool plOneWin, plTwoWin;
    [SerializeField] private BoxCollider2D enemyBox;


    [SerializeField] private Rigidbody2D rbPlOne, rbPlTwo;
    [SerializeField] private GameObject playerOne, playerTwo;
    [SerializeField] private float force;
    [SerializeField] private AudioSource collisionSound, triggerSound;
    [SerializeField] private AudioSource music;

    private void Start()
    {
        if(_summoGameScriptPlTwo.IsMobile && !_summoGameScriptPlTwo.IsSingle)
        {
            playerOnePointsText.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if(!_summoGameScriptPlTwo.IsMobile || _summoGameScriptPlTwo.IsSingle)
        {
            playerOnePointsText.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NotTrigger")
        {
            triggerSound.Play();
            if (playerIndex == 1)
            {
                
                _summoGameScriptPlOne.PlayerOneIsHolding = false;
                _summoGameScriptPlTwo.PlayerTwoIsHolding = false;
                playerOneObject.transform.position = playerOneStartPos.position;
                playerTwoObject.transform.position = playerTwoStartPos.position;
                rbPlOne.velocity = Vector2.zero;
                rbPlTwo.velocity = Vector2.zero;
                PlayerTwoPoints++;
                _plTwoSummoTrigger.PlayerTwoPoints++;
                playerTwoPointsText.text = PlayerTwoPoints.ToString();
                if(PlayerTwoPoints == 3)
                {
                    if (_summoGameScriptPlTwo.IsMobile && !_summoGameScriptPlTwo.IsSingle) // mobile multyplay
                    {
                    //    playerTwoWinMobile.SetActive(true);
                    }
                    if (!_summoGameScriptPlTwo.IsMobile && _summoGameScriptPlTwo.IsSingle)// pc Singleplay
                    {
                   //     playerTwoWinPC.SetActive(true);
                    }
                    if (!_summoGameScriptPlTwo.IsMobile && !_summoGameScriptPlTwo.IsSingle) // pc multyplay
                    {
                   //     playerTwoWinPC.SetActive(true);
                    }
                    if (_summoGameScriptPlTwo.IsMobile && _summoGameScriptPlTwo.IsSingle) // mobile single
                    {
                    //    playerTwoWinPC.SetActive(true);
                    }
                    plTwoWin = true;
                    playerOneButton.interactable = false;
                    playerTwoButton.interactable = false;
                    _summoGameScriptPlOne.GameEnds = true;
                    _summoGameScriptPlTwo.GameEnds = true;
                    StartCoroutine(WaitToWin());
                }
            }
            if (playerIndex == 2)
            {
                _summoGameScriptPlOne.PlayerOneIsHolding = false;
                _summoGameScriptPlTwo.PlayerTwoIsHolding = false;
                playerOneObject.transform.position = playerOneStartPos.position;
                playerTwoObject.transform.position = playerTwoStartPos.position;
                rbPlOne.velocity = Vector2.zero;
                rbPlTwo.velocity = Vector2.zero;
                PlayerOnePoints++;
                _plOneSummoTrigger.PlayerOnePoints++;
                playerOnePointsText.text = PlayerOnePoints.ToString();
                if(PlayerOnePoints == 3)
                {
                    if (_summoGameScriptPlTwo.IsMobile && !_summoGameScriptPlTwo.IsSingle) // mobile multyplay
                    {
                      //  playerOneWinMobile.SetActive(true);
                    }
                    if (!_summoGameScriptPlTwo.IsMobile && _summoGameScriptPlTwo.IsSingle) // pc Singleplay
                    {
                      //  playerOneWinPC.SetActive(true);
                    }
                    if(!_summoGameScriptPlTwo.IsMobile && !_summoGameScriptPlTwo.IsSingle) // pc multyplay
                    {
                      //  playerOneWinPC.SetActive(true);
                    }
                    if(_summoGameScriptPlTwo.IsMobile && _summoGameScriptPlTwo.IsSingle) // mobile single
                    {
                      //  playerOneWinPC.SetActive(true);
                    }
                    plOneWin = true;
                    playerOneButton.interactable = false;
                    playerTwoButton.interactable = false;
                    _summoGameScriptPlOne.GameEnds = true;
                    _summoGameScriptPlTwo.GameEnds = true;
                    enemyBox.enabled = false;
                    StartCoroutine(WaitToWin());
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (playerIndex == 1)
        {
            if (collision.gameObject.tag == "PlayerTwo")
            {
                collisionSound.Play();
                Transform playerTwoHitTransform = playerTwo.transform;
                Vector2 direction = (playerTwoHitTransform.position - transform.position);
                rbPlOne.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }
        if (playerIndex == 2)
        {
            if (collision.gameObject.tag == "PlayerOne")
            {
                collisionSound.Play();
                Transform playerOneHitTransform = playerOne.transform;
                Vector2 direction = (playerOneHitTransform.position - transform.position);
                rbPlTwo.AddForce(direction * force, ForceMode2D.Impulse);
            }

        }
    }
   
    public IEnumerator WaitToWin()
    {
        music.Stop();
        yield return new WaitForSeconds(1f);
        finalPanel.SetActive(true);
        if (plOneWin)
        {
            playerOneWinPC.SetActive(true);
        }
        if (plTwoWin)
        {
            playerTwoWinPC.SetActive(true);
        }
    }
}
