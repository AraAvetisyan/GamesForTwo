using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    [SerializeField] private Rigidbody2D rigidbodyPlayerOne;
    [SerializeField] private Rigidbody2D rigidbodyPlayerTwo;
    [SerializeField] private GameObject playerOne, playerTwo;
    private int playerOneGravity = -1;
    private int playerTwoGravity = 1;
    private bool changeOne, changeTwo;

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
        playerOne.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        playerTwo.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        if (!isMobile && Input.GetKeyDown(KeyCode.Z))
        {
            PressedPlayerTwoButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M))
        {
            PressedPlayerOneButton();
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
        }
        if (playerOneGravity == 1 && changeOne)
        {

            rigidbodyPlayerOne.gravityScale = -1;
            playerOneGravity = -1;
            changeOne = false;
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
        }
        if (playerTwoGravity == 1 && changeTwo)
        {
            changeTwo = false;
            rigidbodyPlayerTwo.gravityScale = -1;
            playerTwoGravity = -1;
        }
    }
}
