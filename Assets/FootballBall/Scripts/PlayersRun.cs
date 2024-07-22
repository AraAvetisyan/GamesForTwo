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

    public bool PlayerOneIsHolding;
    public bool PlayerTwoIsHolding;

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
            if (!IsSingle)
            {
                //Color color = oneBg.color;
                //color.a = 0.0001f;
                //oneBg.color = color;
                //twoBG.color = color;
                //buttonOne.color = color;
                //buttonTwo.color = color;
            }
        }
    }
    

    private void Update()
    {

        if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && !_footballTimer.GameEnds)
        {
          
            if (!MustWait)
            {
                PlayerTwoIsHolding = true;
                Speed = Speed * 0.5f;
            }
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !_footballTimer.GameEnds && !IsSingle)
        {
            if (!MustWait)
            {

                PlayerOneIsHolding = true;
                Speed = Speed * 0.5f;
            }
        }
        if (!IsMobile && Input.GetKeyUp(KeyCode.Z))
        {
            PlayerTwoIsHolding = false;
            Speed = 5f;
            _rotatePlayers.PlayerTwoRotationSpeed = 300f;
        }
        if (!IsMobile && Input.GetKeyUp(KeyCode.M))
        {

            PlayerOneIsHolding = false;
            Speed = 5f;
            _rotatePlayers.PlayerOneRotationSpeed = 300f;
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
        if (!PlayerOneIsHolding && !IsSingle)
        {
            blueRun.SetActive(false);
            blueIdle.SetActive(true);
        }
        if (!PlayerTwoIsHolding)
        {
            redRun.SetActive(false);
            redIdle.SetActive(true);
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
