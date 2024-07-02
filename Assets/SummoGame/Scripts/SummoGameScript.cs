using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SummoGameScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    public int PlayerIndex;
    [SerializeField] private float speed;
    [SerializeField] private GameObject PlayerOne, PlayerTwo;

    public bool PlayerOneIsHolding;
    public bool PlayerTwoIsHolding;

    public bool GameEnds;

    public bool IsMobile;
    public bool IsSingle;

    [SerializeField] private float first,second;
    [SerializeField] private Image buttonOneBg, buttonTwoBg;
    [SerializeField] private Image buttonOne, buttonTwo;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
            if (!IsSingle)
            {
                Color color = buttonOneBg.color;
                color.a = 0.0001f; // Установите желаемое значение альфа-канала (от 0.0 до 1.0)
                buttonOneBg.color = color;
                buttonTwoBg.color = color;
                buttonOne.color = color;
                buttonTwo.color = color;
            }
        }
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        if (GameEnds)
        {
            speed = 0;
            Debug.Log("GameEnds");
        }

        if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && !GameEnds)
        {
            PlayerTwoIsHolding = true;
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !IsSingle && !GameEnds)
        {            
            PlayerOneIsHolding = true;
        }
        if(!IsMobile && Input.GetKeyUp(KeyCode.Z))
        {
            PlayerTwoIsHolding = false;
            _rotatePlayers.PlayerTwoRotationSpeed = 300f;
        }
        if (!IsMobile && Input.GetKeyUp(KeyCode.M) && !IsSingle)
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
    
    public IEnumerator Single()
    {
        float timer = Random.Range(first, second);
        yield return new WaitForSeconds(timer);
        PlayerOneIsHolding = true;
        yield return new WaitForSeconds(.25f);
        PlayerOneIsHolding = false;
        _rotatePlayers.PlayerOneRotationSpeed = 300f;
    }
}
