using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecondPlayerZoneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject firstPlayerGoll;
    [SerializeField] private RotatePlayers _rotatePlayers;
    [SerializeField] private GameObject greenBall;
    [SerializeField] private Transform greenBallStartTransform;
    [SerializeField] private TextMeshProUGUI firstPlayersPointsText;
    public int FirstPlayersPoints;
    [SerializeField] private Button blueButton, redButton;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FirstPlayerWin")
        {
            FirstPlayersPoints++;
            firstPlayersPointsText.text = FirstPlayersPoints.ToString();
            firstPlayerGoll.SetActive(true);
            _rotatePlayers.PlayerOneRotationSpeed = 0;
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
            greenBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            blueButton.interactable = false;
            redButton.interactable = false;
            StartCoroutine(WaitForWin());
        }
    }
    public IEnumerator WaitForWin()
    {
        yield return new WaitForSeconds(2f);
        greenBall.transform.position = greenBallStartTransform.position;
        _rotatePlayers.PlayerOneRotationSpeed = 300;
        _rotatePlayers.PlayerTwoRotationSpeed = 300;
        firstPlayerGoll.SetActive(false);
        blueButton.interactable = true;
        redButton.interactable = true;
    }
}
