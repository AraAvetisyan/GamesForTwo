using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    [SerializeField] private Rigidbody2D rigidbodyPlayerOne;
    [SerializeField] private Rigidbody2D rigidbodyPlayerTwo;
    [SerializeField] private GameObject playerOne, playerTwo;
    private int playerOneGravity = -1;
    private int playerTwoGravity = 1;
    private bool changeOne, changeTwo;
    [SerializeField] private Button plOneButton, plTwoButton;
    [SerializeField] private GameObject plButtonOne, plButtonTwo;

    [SerializeField] private GameObject blueChickenSprite, redChickenSprite;

    public bool IsMobile;
    [SerializeField] private bool isSingle;

    [SerializeField] private PlayersTriggers _firstPlayersTriggers, _secondPlayersTriggers;

    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
            if (!isSingle)
            {
                plButtonOne.SetActive(false);
                plButtonTwo.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (_firstPlayersTriggers.EndGame || _secondPlayersTriggers.EndGame)
        {
            Speed = 0;
            plOneButton.interactable = false;
            plTwoButton.interactable = false;
        }
        playerOne.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        playerTwo.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        if (!IsMobile && Input.GetKeyDown(KeyCode.Z))
        {
            if (!_firstPlayersTriggers.EndGame && !_secondPlayersTriggers.EndGame)
            {
                PressedPlayerTwoButton();
            }
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.M))
        {
            if (!_firstPlayersTriggers.EndGame && !_secondPlayersTriggers.EndGame)
            {
                PressedPlayerOneButton();
            }
        }
    }


    public void PressedPlayerOneButton()
    {
        changeOne = true;
        if (playerOneGravity == -1 && changeOne) 
        {

            rigidbodyPlayerOne.gravityScale = 1;
            playerOneGravity = 1;
            changeOne = false;
            blueChickenSprite.transform.rotation = Quaternion.Euler(0, 0, 180);
            blueChickenSprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (playerOneGravity == 1 && changeOne)
        {

            rigidbodyPlayerOne.gravityScale = -1;
            playerOneGravity = -1;
            changeOne = false;
            blueChickenSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            blueChickenSprite.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void PressedPlayerTwoButton()
    {
        changeTwo = true;
        Debug.Log(playerTwoGravity);
        if (playerTwoGravity == -1 && changeTwo)
        {
            changeTwo = false;
            rigidbodyPlayerTwo.gravityScale = 1;
            playerTwoGravity = 1;
            redChickenSprite.transform.rotation = Quaternion.Euler(0, 0, 180);
            redChickenSprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (playerTwoGravity == 1 && changeTwo)
        {
            changeTwo = false;
            rigidbodyPlayerTwo.gravityScale = -1;
            playerTwoGravity = -1;
            redChickenSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            redChickenSprite.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
