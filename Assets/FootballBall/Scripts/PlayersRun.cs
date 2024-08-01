using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class PlayersRun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    public int PlayerIndex;
    public float Speed;
    [SerializeField] private GameObject playerOne, playerTwo;

    [SerializeField] private Rigidbody2D playerOneRB, playerTwoRB;

    private bool PlayerOneIsHolding;
    private bool PlayerTwoIsHolding;

    [SerializeField] private FootballTimer _footballTimer;

    public bool IsMobile;


    public bool IsSingle;
    [SerializeField] private Image buttonOne, buttonTwo;
    [SerializeField] private Image oneBg, twoBG;
    [SerializeField] private float first, second;

    [SerializeField] private GameObject blueIdle, blueRun, redIdle, redRun;
    public bool MustWait = false;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
            Color color = oneBg.color;
            color.a = 0.0001f;
            oneBg.color = color;
            twoBG.color = color;
            buttonOne.color = color;
            buttonTwo.color = color;
            
        }
    }
    

    private void Update()
    {

        if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && !_footballTimer.GameEnds)
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
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !_footballTimer.GameEnds && !IsSingle)
        {
            if (!MustWait)
            {
                if (PlayerIndex == 1)
                {
                 //   Debug.Log("M a sexme piti poxi run");
                    PlayerOneIsHolding = true;
                    blueRun.SetActive(true);
                    blueIdle.SetActive(false);
                    Speed = Speed * 0.8f;
                }
            }
        }
        if (!IsMobile && Input.GetKeyUp(KeyCode.Z))
        {
            if (PlayerIndex == 2)
            {
                PlayerTwoIsHolding = false;
                Speed = 5f;
                _rotatePlayers.PlayerTwoRotationSpeed = 300f;
            }
        }
        if (!IsMobile && Input.GetKeyUp(KeyCode.M))
        { 
            if (PlayerIndex == 1 && !IsSingle)
            {
             //   Debug.Log("M y toxela piti poxi idle");
                PlayerOneIsHolding = false;
                Speed = 5f;
                _rotatePlayers.PlayerOneRotationSpeed = 300f;
            }
        }


        if (PlayerOneIsHolding)
        {
            blueRun.SetActive(true);
            blueIdle.SetActive(false);

            _rotatePlayers.PlayerOneRotationSpeed = 0;
            playerOne.transform.Translate(-Vector3.right * Speed * Time.deltaTime);
        }
       
        if (PlayerTwoIsHolding)
        {

            redIdle.SetActive(false);
            redRun.SetActive(true);
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
            playerTwo.transform.Translate(Vector3.right * Speed * Time.deltaTime);
            
        }
        if (!PlayerOneIsHolding)
        {

            blueRun.SetActive(false);
            blueIdle.SetActive(true);
            playerOneRB.velocity = Vector2.zero;
        }
        if (!PlayerTwoIsHolding)
        {
            redRun.SetActive(false);
            redIdle.SetActive(true);
            playerTwoRB.velocity = Vector2.zero;
        }
      
    }
    public IEnumerator Single()
    {
        float timer = Random.Range(first, second);
        yield return new WaitForSeconds(timer);
        PlayerOneIsHolding = true;
       
        yield return new WaitForSeconds(1f);
        PlayerOneIsHolding = false;
        blueRun.SetActive(false);
        blueIdle.SetActive(true);
        _rotatePlayers.PlayerOneRotationSpeed = 300f;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (PlayerIndex == 1 && !IsSingle)
        {
            PlayerOneIsHolding = true;
       
        }
        if (PlayerIndex == 2)
        {
            PlayerTwoIsHolding = true;
        
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PlayerIndex == 1 && !IsSingle)
        {

            PlayerOneIsHolding = false;
            _rotatePlayers.PlayerOneRotationSpeed = 300f;
        }
        if (PlayerIndex == 2)
        {
            PlayerTwoIsHolding = false;
         
            _rotatePlayers.PlayerTwoRotationSpeed = 300f;
        }
    }
}
