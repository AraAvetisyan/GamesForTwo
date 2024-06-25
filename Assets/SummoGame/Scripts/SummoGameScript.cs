using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SummoGameScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    [SerializeField] private int playerIndex;
    [SerializeField] private float speed;
    [SerializeField] private GameObject PlayerOne, PlayerTwo;

    public bool PlayerOneIsHolding;
    public bool PlayerTwoIsHolding;


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

        if (!isMobile && Input.GetKeyDown(KeyCode.Z))
        {
            PlayerTwoIsHolding = true;
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M))
        {            
            PlayerOneIsHolding = true;
        }
        if(!isMobile && Input.GetKeyUp(KeyCode.Z))
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
            PlayerOne.transform.Translate(Vector3.left * speed * Time.deltaTime);
            _rotatePlayers.PlayerOneRotationSpeed = 0;
        }
        if (PlayerTwoIsHolding)
        {
            PlayerTwo.transform.Translate(Vector3.right * speed * Time.deltaTime);
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
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
