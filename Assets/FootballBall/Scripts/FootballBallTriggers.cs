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
    
    [SerializeField] private float force;

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
            //StartCoroutine(WaitToFinish());
        }
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
