using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RacingButtonsHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int playerIndex;
    public bool PlayerOneIsHolding;
    public bool PlayerTwoIsHolding;
    private bool isMobile;
    [SerializeField] private FireLightsScript _fireLightsScript;
    public bool PlayerOneSoon, PlayerTwoSoon;
    public bool PlayerOneOnTime, PlayerTwoOnTime;
    public Button PlayerOneButton, PlayerTwoButton;
    [SerializeField] private RacingButtonsHold _racingButtonOneHold;
    [SerializeField] RacingLightGameManager _racingLightGameManager;

    [SerializeField] private bool isSingle;
    public int SingleCounter;

    private void Start()
    {
        //if (Geekplay.Instance.mobile)
        //{
        //    isMobile = true;
        //}
        //else
        //{
        //    isMobile = false;
        //}
    }
    private void Update()
    {




        if (!isMobile && Input.GetKeyDown(KeyCode.Z) && playerIndex == 2 && PlayerTwoButton.interactable)
        {
            PlayerTwoIsHolding = true;
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && playerIndex == 1 && PlayerOneButton.interactable && !isSingle)
        {
            PlayerOneIsHolding = true;
        }
        if (!isMobile && Input.GetKeyUp(KeyCode.Z) && playerIndex == 2)
        {
            PlayerTwoIsHolding = false;
            if (_fireLightsScript.CanHoldOff)
            {
                _racingLightGameManager.counter++;
                PlayerTwoButton.interactable = false;
                PlayerTwoOnTime = true;
                //  Debug.Log("Player 2 i tivy pahel");
            }
            else
            {
                _racingLightGameManager.counter++;
                PlayerTwoSoon = true;
                PlayerTwoButton.interactable = false;
                //    Debug.Log("Player 2 y krvav");
            }
        }
        if (!isMobile && Input.GetKeyUp(KeyCode.M) && playerIndex == 1 && !isSingle)
        {
            PlayerOneIsHolding = false;
            if (_fireLightsScript.CanHoldOff)
            {
                _racingLightGameManager.counter++;
                PlayerOneButton.interactable = false;
                PlayerOneOnTime = true;
                //   Debug.Log("Player 1 i tivy pahel");
            }
            else
            {
                _racingLightGameManager.counter++;
                PlayerOneSoon = true;
                PlayerOneButton.interactable = false;
                //   Debug.Log("Player 1 y krvav");
            }
        }


    }
    public IEnumerator Single()
    {
        float timer = Random.Range(7.5f, 9);
        yield return new WaitForSeconds(timer);
        _racingButtonOneHold.PlayerOneIsHolding = false;
        if (_fireLightsScript.CanHoldOff)
        {
            _racingLightGameManager.counter++;
            _racingButtonOneHold.PlayerOneOnTime = true;
            _racingButtonOneHold.PlayerOneButton.interactable = false;
            //   Debug.Log("Player 1 i tivy pahel");
        }
        else
        {
            _racingLightGameManager.counter++;
            _racingButtonOneHold.PlayerOneSoon = true;
            _racingButtonOneHold.PlayerOneButton.interactable = false;
            //   Debug.Log("Player 1 y krvav");
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerIndex == 1 && !isSingle)
        {
            PlayerOneIsHolding = true;

        }
        if (playerIndex == 2 && !isSingle)
        {
            PlayerTwoIsHolding = true;
        }
        if(playerIndex == 2 && isSingle)
        {
            _racingButtonOneHold.PlayerOneIsHolding = true;
            PlayerTwoIsHolding = true;
            if(SingleCounter == 0)
            {
                SingleCounter++;
                StartCoroutine(Single());
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playerIndex == 1)
        {
            PlayerOneIsHolding = false;
            if (_fireLightsScript.CanHoldOff)
            {
                _racingLightGameManager.counter++;
                PlayerOneOnTime = true;
                PlayerOneButton.interactable = false;
                //   Debug.Log("Player 1 i tivy pahel");
            }
            else
            {
                _racingLightGameManager.counter++;
                PlayerOneSoon = true;
                PlayerOneButton.interactable = false;
                //   Debug.Log("Player 1 y krvav");
            }
        }
        if (playerIndex == 2)
        {
            PlayerTwoIsHolding = false;
            if (_fireLightsScript.CanHoldOff)
            {
                _racingLightGameManager.counter++;
                PlayerTwoOnTime = true;
                PlayerTwoButton.interactable = false;
                //   Debug.Log("Player 2 i tivy pahel");
            }
            else
            {
                _racingLightGameManager.counter++;
                PlayerTwoSoon = true;
                PlayerTwoButton.interactable = false;
                //   Debug.Log("Player 2 y krvav");
            }
        }
    }



}