using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FootballPlayerTwoRun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    public int PlayerIndex;
    public float Speed;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private Rigidbody2D playerTwoRB;

    private bool PlayerTwoIsHolding;

    [SerializeField] private FootballTimer _footballTimer;

    public bool IsMobile;
    public bool IsSingle;
    [SerializeField] private Image buttonTwo;
    [SerializeField] private Image twoBG;

    [SerializeField] private GameObject redIdle, redRun;
    public bool MustWait = false;
   // [SerializeField] private AudioSource runSound;
    private int runCounter;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
            Color color = twoBG.color;
            color.a = 0.0001f;
            twoBG.color = color;
            buttonTwo.color = color;
            
        }
    }


    private void Update()
    {

        if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && !_footballTimer.GameEnds && !IsSingle)
        {

            if (!MustWait)
            {
                if (PlayerIndex == 2)
                {
                    PlayerTwoIsHolding = true;
                    redIdle.SetActive(false);
                    redRun.SetActive(true);
                    Speed = Speed * 0.8f;
                }
            }
        }
    
        if (!IsMobile && Input.GetKeyUp(KeyCode.Z) && !IsSingle)
        {
            if (PlayerIndex == 2)
            {
                PlayerTwoIsHolding = false;
                Speed = 5f;
                _rotatePlayers.PlayerTwoRotationSpeed = 300f;
            }
        }

        if (!IsMobile && Input.GetKeyDown(KeyCode.Space) && !_footballTimer.GameEnds && IsSingle)
        {

            if (!MustWait)
            {
                if (PlayerIndex == 2)
                {
                    PlayerTwoIsHolding = true;
                    redIdle.SetActive(false);
                    redRun.SetActive(true);
                    Speed = Speed * 0.8f;
                }
            }
        }

        if (!IsMobile && Input.GetKeyUp(KeyCode.Space) && IsSingle)
        {
            if (PlayerIndex == 2)
            {
                PlayerTwoIsHolding = false;
                Speed = 5f;
                _rotatePlayers.PlayerTwoRotationSpeed = 300f;
            }
        }

        if (PlayerTwoIsHolding)
        {
            if (runCounter == 0)
            {
                runCounter = 1;
                //runSound.Play();
            }
            redIdle.SetActive(false);
            redRun.SetActive(true);
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
            playerTwo.transform.Translate(Vector3.right * Speed * Time.deltaTime);

        }
       
        if (!PlayerTwoIsHolding)
        {
            runCounter = 0;
           // runSound.Stop();
            redRun.SetActive(false);
            redIdle.SetActive(true);

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

            _rotatePlayers.PlayerTwoRotationSpeed = 300f;
        }
    }
}
