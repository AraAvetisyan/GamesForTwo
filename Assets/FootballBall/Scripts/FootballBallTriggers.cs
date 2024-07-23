using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FootballBallTriggers : MonoBehaviour
{
    public int PlayerOnePoints, PlayerTwoPoints;
    [SerializeField] private TextMeshProUGUI playerOnePointsText, playerTwoPointsText;
    [SerializeField] private Transform playerOneStartTransform, playerTwoStartTransform, ballStartTransform;
    [SerializeField] private GameObject playerOne, playerTwo;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D playerOneRigidbody, playerTwoRigidbody;
    [SerializeField] private FootballPlayerOneRun _playerOneRun;
    [SerializeField] private FootballPlayerTwoRun _playerTwoRun;
    [SerializeField] private float force;
    [SerializeField] private GameObject gollTimerGameobject;
    [SerializeField] private TextMeshProUGUI gollTimer;
    [SerializeField] private CircleCollider2D circleCollider;
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
        }
    }
    public IEnumerator Timer()
    {
        _playerOneRun.MustWait = true;
        _playerTwoRun.MustWait = true;
        gollTimerGameobject.SetActive(true);
        gollTimer.text = "3";
        yield return new WaitForSecondsRealtime(1);
        gollTimer.text = "2";
        yield return new WaitForSecondsRealtime(1);
        gollTimer.text = "1";
        yield return new WaitForSecondsRealtime(1);
        gollTimer.text = "0";
        gollTimerGameobject.SetActive(false);
        _playerOneRun.MustWait = false;
        _playerTwoRun.MustWait = false;
        _playerOneRun.Speed = 5;
        _playerTwoRun.Speed = 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerOne")
        {
            Transform playerOneHitTransform = playerOne.transform;
            Vector2 direction = (playerOneHitTransform.position - transform.position).normalized;
            rb.AddForce(-direction * force);
            StartCoroutine(OffCollider());
        }
        if (collision.gameObject.tag == "PlayerTwo")
        {
            Transform playerTwoHitTransform = playerTwo.transform;
            Vector2 direction = (playerTwoHitTransform.position - transform.position).normalized;
            rb.AddForce(-direction * force);
            StartCoroutine(OffCollider());
        }
    }
    public IEnumerator OffCollider()
    {
        yield return new WaitForSeconds(0.02f);
    }
    public IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
