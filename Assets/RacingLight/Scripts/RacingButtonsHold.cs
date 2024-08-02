

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
    public bool IsMobile;
    [SerializeField] private FireLightsScript _fireLightsScript;
    public bool PlayerOneSoon, PlayerTwoSoon;
    public bool PlayerOneOnTime, PlayerTwoOnTime;
    public Button PlayerOneButton, PlayerTwoButton;
    [SerializeField] private RacingButtonsHold _racingButtonOneHold;
    [SerializeField] RacingLightGameManager _racingLightGameManager;
    public bool IsSingle;
    public int SingleCounter;
    [SerializeField] private Image buttonOneBg, buttonTwoBg;
    [SerializeField] private Image buttonOne, buttonTwo;
    public bool CantHold;

    [SerializeField] private AudioSource buttonRedSound, buttonBlueSound;
    private int redAudioCounter, blueAudioCounter;
    public GameObject blockerOne, blockerTwo;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;

            Color color = buttonOneBg.color;
            color.a = 0.0001f;
            buttonOneBg.color = color;
            buttonTwoBg.color = color;
            buttonOne.color = color;
            buttonTwo.color = color;

        }
    }
    private void Start()
    {
        if (IsSingle)
        {
            Color color = buttonOneBg.color;
            color.a = 0.0001f;
            buttonOneBg.color = color;
            buttonOne.color = color;
        }
    }
    private void Update()
    {
        if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && playerIndex == 2) // karmir pl pc 77
        {
            if (!CantHold)
            {
                PlayerTwoIsHolding = true;
                
                buttonRedSound.Play();
                
                if (IsSingle) // karmir pl pc ete menak a 88
                {
                    if (SingleCounter == 0)
                    {
                        Debug.Log("Mtav"); 
                        _racingButtonOneHold.PlayerOneIsHolding = true;
                        SingleCounter++;
                        buttonBlueSound.Play();
                        StartCoroutine(Single());
                    }
                } // 88
            }
        }// 77
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && playerIndex == 1 )
        {
            if (!CantHold)
            {
                PlayerOneIsHolding = true;
                buttonBlueSound.Play();
            }
        }
        if (!IsMobile && Input.GetKeyUp(KeyCode.Z) && playerIndex == 2)
        {
            if (PlayerTwoIsHolding)
            {
                PlayerTwoIsHolding = false;
                if (_fireLightsScript.CanHoldOff)
                {
                    _racingLightGameManager.counter++;
                    PlayerTwoButton.interactable = false;
                    PlayerTwoOnTime = true;
                }
                else
                {
                    _racingLightGameManager.counter++;
                    PlayerTwoSoon = true;
                    PlayerTwoButton.interactable = false;
                }
            }
        }
        if (!IsMobile && Input.GetKeyUp(KeyCode.M) && playerIndex == 1 && !IsSingle)
        {
            if (PlayerOneIsHolding)
            {
                PlayerOneIsHolding = false;
                if (_fireLightsScript.CanHoldOff)
                {
                    _racingLightGameManager.counter++;
                    PlayerOneButton.interactable = false;
                    PlayerOneOnTime = true;
                }
                else
                {
                    _racingLightGameManager.counter++;
                    PlayerOneSoon = true;
                    PlayerOneButton.interactable = false;
                }
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
        }
        else
        {
            _racingLightGameManager.counter++;
            _racingButtonOneHold.PlayerOneSoon = true;
            _racingButtonOneHold.PlayerOneButton.interactable = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (playerIndex == 1 && !IsSingle)
        {
            PlayerOneIsHolding = true;
            if (blueAudioCounter == 0)
            {
                blueAudioCounter = 1;
                buttonBlueSound.Play();
            }
        }
        if (playerIndex == 2 && !IsSingle)
        {
            PlayerTwoIsHolding = true;
            if (redAudioCounter == 0)
            {
                redAudioCounter = 1;
                buttonRedSound.Play();
            }
        }
        if (playerIndex == 2 && IsSingle)
        {
            if (redAudioCounter == 0)
            {
                redAudioCounter = 1;
                buttonRedSound.Play();
            }
            _racingButtonOneHold.PlayerOneIsHolding = true;
            PlayerTwoIsHolding = true;
            if (SingleCounter == 0)
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
            blockerOne.SetActive(true);
            blueAudioCounter = 0;
            
        }
        if (playerIndex == 2)
        {
           
            blockerTwo.SetActive(true);
            redAudioCounter = 0;
        }
        if (playerIndex == 1)
        {
            PlayerOneIsHolding = false;
            if (_fireLightsScript.CanHoldOff)
            {
                _racingLightGameManager.counter++;
                PlayerOneOnTime = true;
                PlayerOneButton.interactable = false;
            }
            else
            {
                _racingLightGameManager.counter++;
                PlayerOneSoon = true;
                PlayerOneButton.interactable = false;
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
            }
            else
            {
                _racingLightGameManager.counter++;
                PlayerTwoSoon = true;
                PlayerTwoButton.interactable = false;
            }
        }
    }
}
