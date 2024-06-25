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
    [SerializeField] RacingLightGameManager _racingLightGameManager;
    
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
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && playerIndex == 1 && PlayerOneButton.interactable)
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
        if (!isMobile && Input.GetKeyUp(KeyCode.M) && playerIndex == 1)
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
    public void OnPointerDown(PointerEventData eventData)
    {
        if(playerIndex == 1)
        {
            PlayerOneIsHolding = true;

        }
        if(playerIndex == 2)
        {
            PlayerTwoIsHolding = true;
        }
        Debug.Log("Начало удерживания кнопки");
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
        Debug.Log("Конец удерживания кнопки");
    }


  
}
