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

    private bool isMobile;


    public bool IsSingle;
    [SerializeField] private Image buttonOne, buttonTwo;
    [SerializeField] private Image oneBg, twoBG;
    [SerializeField] private float first, second;

    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
            if (!IsSingle)
            {
                Color color = oneBg.color;
                color.a = 0.0001f; // Установите желаемое значение альфа-канала (от 0.0 до 1.0)
                oneBg.color = color;
                twoBG.color = color;
                buttonOne.color = color;
                buttonTwo.color = color;
            }
        }
    }

    private void Update()
    {

        if (!isMobile && Input.GetKeyDown(KeyCode.Z) && !_footballTimer.GameEnds)
        {
            PlayerTwoIsHolding = true;
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && !_footballTimer.GameEnds && !IsSingle)
        {
            PlayerOneIsHolding = true;
        }
        if (!isMobile && Input.GetKeyUp(KeyCode.Z))
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
            _rotatePlayers.PlayerOneRotationSpeed = 0;



            playerOne.transform.Translate(-Vector3.right * Speed * Time.deltaTime);
            //Vector2 runDirection = -playerOne.transform.right;
            //playerOneRB.AddForce(runDirection * speed, ForceMode2D.Force);



        }
        if (PlayerTwoIsHolding)
        {
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
            playerTwo.transform.Translate(Vector3.right * Speed * Time.deltaTime);
            //Vector2 runDirection = playerTwo.transform.right;
            //playerTwoRB.AddForce(runDirection * speed, ForceMode2D.Force);
            
        }
    }
    public IEnumerator Single()
    {
        float timer = Random.Range(first, second);
        yield return new WaitForSeconds(timer);
        PlayerOneIsHolding = true;
        yield return new WaitForSeconds(1f);
        PlayerOneIsHolding = false;
        _rotatePlayers.PlayerOneRotationSpeed = 300f;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (PlayerIndex == 1)
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
        if (PlayerIndex == 1)
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
