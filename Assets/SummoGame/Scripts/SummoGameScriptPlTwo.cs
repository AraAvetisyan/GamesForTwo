using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SummoGameScriptPlTwo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    public int PlayerIndex;
    [SerializeField] private float speed;
    [SerializeField] private GameObject  PlayerTwo;

    public bool PlayerTwoIsHolding;

    public bool GameEnds;

    public bool IsMobile;
    public bool IsSingle;

    [SerializeField] private float first, second;
    [SerializeField] private Image buttonTwoBg;
    [SerializeField] private Image buttonTwo;

    [SerializeField] private Rigidbody2D rbPlTwo;
    [SerializeField] private Transform plTwoTransform;

    public GameObject PlTwoIdle, PlTwoRunning;
    [SerializeField] private GameObject buttonBackground;
    //public bool Fall;
    private bool canPlay;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
            buttonBackground.SetActive(false);
            Color color = buttonTwoBg.color;
            color.a = 0.0001f; // Установите желаемое значение альфа-канала (от 0.0 до 1.0)

            buttonTwoBg.color = color;

            buttonTwo.color = color;
            if (!IsSingle)
            {
                
            }
        }
    }

    private void OnEnable()
    {
        SummoGameStartScript.SummoGameStarts += GameStart;
    }
    private void OnDisable()
    {
        SummoGameStartScript.SummoGameStarts -= GameStart;
    }
    public void GameStart(int i)
    {
        canPlay = true;
    }

    private void Update()
    {
        if (canPlay)
        {
            if (GameEnds)
            {
                speed = 0;
                //    Debug.Log("GameEnds");
            }

            if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && !GameEnds)
            {
                PlayerTwoIsHolding = true;
            }

            if (!IsMobile && Input.GetKeyUp(KeyCode.Z))
            {
                PlayerTwoIsHolding = false;
                _rotatePlayers.PlayerTwoRotationSpeed = 300f;
            }




            if (PlayerTwoIsHolding)
            {
                PlTwoIdle.SetActive(false);
                PlTwoRunning.SetActive(true);

                rbPlTwo.freezeRotation = true;
                Vector2 dir = plTwoTransform.right;
                rbPlTwo.velocity = dir * speed * Time.deltaTime;
                _rotatePlayers.PlayerTwoRotationSpeed = 0;
            }

            if (!PlayerTwoIsHolding)
            {
                PlTwoIdle.SetActive(true);
                PlTwoRunning.SetActive(false);

                //   Debug.Log("!PlayerTwoIsHolding");
                rbPlTwo.velocity = Vector2.zero;
            }



        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {

       
        if (PlayerIndex == 2)
        {
            PlayerTwoIsHolding = true;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      
        if (PlayerIndex == 2)
        {
            PlayerTwoIsHolding = false;
            rbPlTwo.freezeRotation = false;
            _rotatePlayers.PlayerTwoRotationSpeed = 300f;
        }
    }

   
}

