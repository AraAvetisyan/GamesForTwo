using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayersRun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    [SerializeField] private int playerIndex;
    [SerializeField] private float speed;
    [SerializeField] private GameObject playerOne, playerTwo;

    [SerializeField] private Rigidbody2D playerOneRB, playerTwoRB;

    public bool PlayerOneIsHolding;
    public bool PlayerTwoIsHolding;

    [SerializeField] private FootballTimer _footballTimer;

    private bool isMobile;

    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
        }
    }

    private void Update()
    {

        if (!isMobile && Input.GetKeyDown(KeyCode.Z) && !_footballTimer.GameEnds)
        {
            PlayerTwoIsHolding = true;
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && !_footballTimer.GameEnds)
        {
            PlayerOneIsHolding = true;
        }
        if (!isMobile && Input.GetKeyUp(KeyCode.Z))
        {
            PlayerTwoIsHolding = false;
            _rotatePlayers.PlayerTwoRotationSpeed = 300f;
        }
        if (!isMobile && Input.GetKeyUp(KeyCode.M))
        {
            PlayerOneIsHolding = false;
            _rotatePlayers.PlayerOneRotationSpeed = 300f;
        }


        if (PlayerOneIsHolding)
        {
            _rotatePlayers.PlayerOneRotationSpeed = 0;



            playerOne.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            //Vector2 runDirection = -playerOne.transform.right;
            //playerOneRB.AddForce(runDirection * speed, ForceMode2D.Force);



        }
        if (PlayerTwoIsHolding)
        {
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
            playerTwo.transform.Translate(Vector3.right * speed * Time.deltaTime);
            //Vector2 runDirection = playerTwo.transform.right;
            //playerTwoRB.AddForce(runDirection * speed, ForceMode2D.Force);
            
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (playerIndex == 1)
        {
            PlayerOneIsHolding = true;

        }
        if (playerIndex == 2)
        {
            PlayerTwoIsHolding = true;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playerIndex == 1)
        {
            PlayerOneIsHolding = false;
            _rotatePlayers.PlayerOneRotationSpeed = 300f;
        }
        if (playerIndex == 2)
        {
            PlayerTwoIsHolding = false;
            _rotatePlayers.PlayerTwoRotationSpeed = 300f;
        }
    }
}
