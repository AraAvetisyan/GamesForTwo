using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FootballPlayerOneRun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    public int PlayerIndex;
    public float Speed;
    [SerializeField] private GameObject playerOne;

    [SerializeField] private Rigidbody2D playerOneRB;

    public bool PlayerOneIsHolding;

    [SerializeField] private FootballTimer _footballTimer;

    public bool IsMobile;
    public bool IsSingle;
    [SerializeField] private Image buttonOne;
    [SerializeField] private Image oneBg;
    [SerializeField] private float first, second;

    [SerializeField] private GameObject blueIdle, blueRun;
    public bool MustWait = false;
    [SerializeField] private AudioSource runSound;
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
            Color color = oneBg.color;
            color.a = 0.0001f;
            oneBg.color = color;
            buttonOne.color = color;
           
        }
    }
    private void Start()
    {
        if (IsSingle)
        {
            Color color = oneBg.color;
            color.a = 0.0001f;
            oneBg.color = color;
            buttonOne.color = color;
        }
    }

    private void Update()
    {


        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !_footballTimer.GameEnds)
        {
            if (!MustWait)
            {
                if (PlayerIndex == 1)
                {
                    PlayerOneIsHolding = true;
                    blueIdle.SetActive(false);
                    blueRun.SetActive(true);
                    Speed = Speed * 0.8f;
                }
            }
        }

        if (!IsMobile && Input.GetKeyUp(KeyCode.M))
        {
            if (PlayerIndex == 1)
            {
                PlayerOneIsHolding = false;
                Speed = 5f;
                _rotatePlayers.PlayerOneRotationSpeed = 300f;
            }
        }


        if (PlayerOneIsHolding)
        {
            if (runCounter == 0)
            {
                runSound.Play();
                runCounter = 1;
            }
            blueRun.SetActive(true);
            blueIdle.SetActive(false);

            _rotatePlayers.PlayerOneRotationSpeed = 0;
            playerOne.transform.Translate(-Vector3.right * Speed * Time.deltaTime);
        }

        
        if (!PlayerOneIsHolding)
        {

            runSound.Stop();
            runCounter = 0;
            //  Debug.Log("PlayerOneIsHolding darela fales petqa poxi idle");
            blueRun.SetActive(false);
            blueIdle.SetActive(true);

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
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PlayerIndex == 1 && !IsSingle)
        {

            PlayerOneIsHolding = false;
            _rotatePlayers.PlayerOneRotationSpeed = 300f;
        }
       
    }
}
