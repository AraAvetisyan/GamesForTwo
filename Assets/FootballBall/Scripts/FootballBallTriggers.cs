using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FootballBallTriggers : MonoBehaviour
{
    public int PlayerOnePoints, PlayerTwoPoints;
    [SerializeField] private TextMeshProUGUI playerOnePointsText, playerTwoPointsText;
   // [SerializeField] private GameObject finalPanel;
    [SerializeField] private Transform playerOneStartTransform, playerTwoStartTransform, ballStartTransform;
    [SerializeField] private GameObject playerOne, playerTwo;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D playerOneRigidbody, playerTwoRigidbody;
    [SerializeField] private PlayersRun _playerOneRun, _playerTwoRun;
    [SerializeField] private float force;
    [SerializeField] private GameObject gollTimerGameobject;
    [SerializeField] private TextMeshProUGUI gollTimer;
    private void Start()
    {
        if(_playerTwoRun.IsMobile && !_playerTwoRun.IsSingle)
        {
            playerOnePointsText.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        if(!_playerTwoRun.IsMobile || _playerTwoRun.IsSingle)
        {
            playerOnePointsText.transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SecondPlayerWin")
        {
            PlayerTwoPoints++;
            playerTwoPointsText.text = PlayerTwoPoints.ToString();
            playerOne.transform.position = playerOneStartTransform.position;
            playerTwo.transform.position = playerTwoStartTransform.position;
            transform.position = ballStartTransform.position;
            rb.velocity = Vector2.zero;
            playerOneRigidbody.velocity = Vector2.zero;
            playerTwoRigidbody.velocity = Vector2.zero;
            _playerOneRun.Speed = 0;
            _playerTwoRun.Speed = 0;
            StartCoroutine(Timer());
            //StartCoroutine(WaitToFinish());
        }
        if (collision.gameObject.tag == "FirstPlayerWin")
        {
            PlayerOnePoints++;
            playerOnePointsText.text = PlayerOnePoints.ToString();
            playerOne.transform.position = playerOneStartTransform.position;
            playerTwo.transform.position = playerTwoStartTransform.position;
            transform.position = ballStartTransform.position;
            rb.velocity = Vector2.zero;
            playerOneRigidbody.velocity = Vector2.zero;
            playerTwoRigidbody.velocity = Vector2.zero;
            _playerOneRun.Speed = 0;
            _playerTwoRun.Speed = 0;
            StartCoroutine(Timer());
            //StartCoroutine(WaitToFinish());
        }
    }
    public IEnumerator Timer()
    {
        gollTimerGameobject.SetActive(true);
        gollTimer.text = "3";
        yield return new WaitForSecondsRealtime(1);
        gollTimer.text = "2";
        yield return new WaitForSecondsRealtime(1);
        gollTimer.text = "1";
        yield return new WaitForSecondsRealtime(1);
        gollTimer.text = "0";
        gollTimerGameobject.SetActive(false);
        _playerOneRun.Speed = 5;
        _playerTwoRun.Speed = 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerOne")
        {
            Transform playerOneHitTransform = playerOne.transform;
            Vector2 direction = (playerOneHitTransform.position - transform.position).normalized;
            rb.AddForce(direction * force);
        }
        if (collision.gameObject.tag == "PlayerTwo")
        {
            Transform playerTwoHitTransform = playerTwo.transform;
            Vector2 direction = (playerTwoHitTransform.position - transform.position).normalized;
            rb.AddForce(-direction * force);
        }
    }

    public IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1.5f);
       // finalPanel.SetActive(true);
    }
}
