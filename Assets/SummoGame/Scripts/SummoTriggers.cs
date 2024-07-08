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
    [SerializeField] private SummoGameScript _summoGameScriptPlOne, _summoGameScriptPlTwo;
    [SerializeField] private SummoTriggers _plOneSummoTrigger, _plTwoSummoTrigger;

    [SerializeField] private Button playerOneButton, playerTwoButton;

    [SerializeField] private GameObject playerOneWinMobile, playerTwoWinMobile;
    [SerializeField] private GameObject playerOneWinPC, playerTwoWinPC;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private BoxCollider2D enemyBox;


    [SerializeField] private Rigidbody2D rbPlOne, rbPlTwo;
    [SerializeField] private GameObject playerOne, playerTwo;
    [SerializeField] private float force;


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
                    if (_summoGameScriptPlTwo.IsMobile && !_summoGameScriptPlTwo.IsSingle)
                    {
                        playerTwoWinMobile.SetActive(true);
                    }
                    if (!_summoGameScriptPlTwo.IsMobile || _summoGameScriptPlTwo.IsSingle)
                    {
                        playerTwoWinPC.SetActive(true);
                    }
                    playerOneButton.interactable = false;
                    playerTwoButton.interactable = false;
                    _summoGameScriptPlOne.GameEnds = true;
                    _summoGameScriptPlTwo.GameEnds = true;
                    StartCoroutine(WaitToWin());
                }
                Debug.Log("Pl 2 Win");
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
                    if (_summoGameScriptPlTwo.IsMobile && !_summoGameScriptPlTwo.IsSingle)
                    {
                        playerOneWinMobile.SetActive(true);
                    }
                    if (!_summoGameScriptPlTwo.IsMobile || _summoGameScriptPlTwo.IsSingle)
                    {
                        playerOneWinPC.SetActive(true);
                    }
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
                Transform playerTwoHitTransform = playerTwo.transform;
                Vector2 direction = (playerTwoHitTransform.position - transform.position);
                rbPlOne.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }
        if (playerIndex == 2)
        {
            if (collision.gameObject.tag == "PlayerOne")
            {
                Transform playerOneHitTransform = playerOne.transform;
                Vector2 direction = (playerOneHitTransform.position - transform.position);
                rbPlTwo.AddForce(direction * force, ForceMode2D.Impulse);
            }

        }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (playerIndex == 1)
    //    {
    //        if (collision.gameObject.tag == "PlayerTwo")
    //        {
    //            rbPlOne.velocity = Vector2.zero;
    //            rbPlTwo.velocity = Vector2.zero;
    //        }
    //    }
    //    if (playerIndex == 2)
    //    {
    //        if (collision.gameObject.tag == "PlayerOne")
    //        {
    //            rbPlOne.velocity = Vector2.zero;
    //            rbPlTwo.velocity = Vector2.zero;
    //        }

    //    }
    //}
    public IEnumerator WaitToWin()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
