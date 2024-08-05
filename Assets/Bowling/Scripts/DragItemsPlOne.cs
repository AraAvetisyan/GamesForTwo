using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragItemsPlOne : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private RectTransform lastRectTransform;
    [SerializeField] private RectTransform startTransform;
    [SerializeField] private bool cantDrag;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    public int HitCounter;
    public bool HidePin;
    public bool HitLine;
    public bool PlayerOneTurn;
    public bool AddPoints;
    public int GameCount;
    public bool StartNewGame;
    [SerializeField] private GameObject playerTwo, playerTwoPins;
    [SerializeField] private PlayersPoints _playersPoints;
    [SerializeField] private DragItemsPlTwo _dragItemsPlTwo;
    [SerializeField] private GameObject[] Pins;
    [SerializeField] private Transform[] pinsStartPos;
    [SerializeField] private GameObject[] PinsPlTwo;
    
    [SerializeField] private AudioSource ballAudio, pinAudio;
    private int pinAudioCounter;

    [SerializeField] private bool isSingle;
    [SerializeField] private GameObject blueInstruction, redInstruction;
    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        StartCoroutine(Position());
    }
    private void Update()
    {
        if (StartNewGame)
        {
            StartNewGame = false;
            GameCount++;
        }
        if(HitCounter == 3)
        {
            HidePin = true;
            cantDrag = true;
            StartCoroutine(Hide());
        }
        if (_playersPoints.StrikePlayerOne)
        {
            HidePin = true;
            cantDrag = true;
            StartCoroutine(Hide());
            _playersPoints.StrikePlayerOne = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!cantDrag)
        {
            rectTransform.anchoredPosition += eventData.delta;

        }
    }
    public IEnumerator Position()
    {
        yield return new WaitForSeconds(0.25f);
        lastRectTransform.position = rectTransform.position;
        if (!cantDrag)
        {
            StartCoroutine(Position());
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StartLine")
        {
            ballAudio.Play();
            HitLine = true;
            cantDrag = true;
            Transform playerLineHit = lastRectTransform;
            Vector2 direction = (playerLineHit.position - transform.position).normalized;

            rb.AddForce(-direction * force);
            HitCounter++;
            if (HitCounter < 3)
            {
                StartCoroutine(WaitToStop());
            }
            //rb.velocity = -direction * force;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pins")
        {
            if (pinAudioCounter == 0)
            {
                pinAudioCounter = 1;
                pinAudio.Play();
            }
        }
    }
    public IEnumerator Hide()
    {
        HitCounter = 0;
        yield return new WaitForSeconds(0.01f);
        lastRectTransform.position = startTransform.position;
        GameCount++;
        for (int i = 0; i < Pins.Length; i++) 
        {
            Pins[i].SetActive(true);
            Pins[i].transform.position = pinsStartPos[i].position;
            Pins[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            Pins[i].SetActive(false);
        }
       
        this.gameObject.SetActive(false);
        cantDrag = false;
        HidePin = false;
        PlayerOneTurn = false;
        if (!_playersPoints.GameEnds)
        {
            if (isSingle)
            {
                redInstruction.SetActive(false);
            }
            if (!isSingle)
            {
                redInstruction.SetActive(false);
                blueInstruction.SetActive(true);
            }
            playerTwo.SetActive(true);
            playerTwoPins.SetActive(true);
            for (int i = 0; i < PinsPlTwo.Length; i++)
            {
                PinsPlTwo[i].SetActive(true);
            }
            _dragItemsPlTwo.PlayerTwoTurn = true;
            _dragItemsPlTwo.StartNewGame = true;
            if (_dragItemsPlTwo.IsSingle && _dragItemsPlTwo.FirstHit)
            {
                _dragItemsPlTwo.StartNewCorutine = true;
            }
        }
    }
   
    public IEnumerator WaitToStop()
    {
        yield return new WaitForSeconds(4);
        rectTransform.position = startTransform.position;
        rb.velocity = Vector2.zero;
        AddPoints = true;
        cantDrag = false;
        HitLine = false;
        StartCoroutine(Position());
        pinAudioCounter = 0;
        if(HitCounter == 2)
        {
            HitCounter++;
        }
    }
}
