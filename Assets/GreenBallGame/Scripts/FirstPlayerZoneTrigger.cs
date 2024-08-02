using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstPlayerZoneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject secondPlayerGoll;
    [SerializeField] private RotatePlayers _rotatePlayers;
    [SerializeField] private GameObject greenBall;
    [SerializeField] private Transform greenBallStartTransform;
    [SerializeField] private TextMeshProUGUI secondPlayersPointsText;
    public int SecondPlayersPoints;
    [SerializeField] private Button blueButton, redButton;
    public bool CanFireBlue, CanFireRed;
    [SerializeField] private GreenBallGameUIController _greenBallGameUIController;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private AudioSource goalAudio;
    private void Start()
    {

        CanFireBlue = true;
        CanFireRed = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "SecondPlayerWin")
        {
            goalAudio.Play();
            SecondPlayersPoints++;
            secondPlayersPointsText.text = SecondPlayersPoints.ToString();
            secondPlayerGoll.SetActive(true);
            _rotatePlayers.PlayerOneRotationSpeed = 0;
            _rotatePlayers.PlayerTwoRotationSpeed = 0;

            //greenBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            blueButton.interactable = false; 
            redButton.interactable = false;
            CanFireBlue = false;
            CanFireRed = false;
            ballRigidbody.mass = 100000;
            ballRigidbody.velocity = Vector3.zero;
            StartCoroutine(WaitForWin());
        }
    }
    public IEnumerator WaitForWin()
    {
        yield return new WaitForSeconds(2f);
        greenBall.transform.position = greenBallStartTransform.position;
        ballRigidbody.mass = 30;
        _rotatePlayers.PlayerOneRotationSpeed = 300;
        _rotatePlayers.PlayerTwoRotationSpeed = 300;
        secondPlayerGoll.SetActive(false);
        blueButton.interactable = true;
        redButton.interactable = true;
        CanFireBlue = true;
        CanFireRed = true;
        if (_greenBallGameUIController.Single)
        {
            StartCoroutine(_greenBallGameUIController.SinglePlayer());
        }
    }
}
