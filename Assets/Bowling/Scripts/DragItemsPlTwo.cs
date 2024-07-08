using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItemsPlTwo : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
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
    public bool PlayerTwoTurn;
    public bool AddPoints;
    public int GameCount;
    public bool StartNewCorutine;
    public bool StartNewGame;
    [SerializeField] private GameObject playerOne, playerOnePins;
    
    [SerializeField] private PlayersPoints _playersPoints;
    [SerializeField] private DragItemsPlOne _dragItemsPlOne;
    [SerializeField] private GameObject[] Pins;
    [SerializeField] private Transform[] pinsStartPos;
    [SerializeField] private GameObject[] PinsPlOne;

    public bool IsSingle;
    [SerializeField] private Transform[] singleTransforms;
    public bool FirstHit;
    private void Awake()
    {

        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        StartCoroutine(Position());
        if (IsSingle)
        {
            StartCoroutine(Single());
            FirstHit = true;
        }
    }
    private void Update()
    {
        if (StartNewCorutine)
        {
            StartNewCorutine = false;
            StartCoroutine(Single());
        }
        if (StartNewGame)
        {
            StartNewGame = false;
            GameCount++;
        }
        if (HitCounter == 3)
        {
            HidePin = true;
            cantDrag = true;
            StartCoroutine(Hide());
        }
        if (_playersPoints.StrikePlayerTwo)
        {
            HidePin = true;
            cantDrag = true;
            StartCoroutine(Hide());
            _playersPoints.StrikePlayerTwo = false;
        }
    }
    public IEnumerator Single()
    {
        int rand = Random.Range(0, singleTransforms.Length);
        yield return new WaitForSeconds(1f);      
        Transform playerLineHit = singleTransforms[rand];
        Vector2 direction = (playerLineHit.position - transform.position).normalized;
        rb.AddForce(-direction * force);
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!cantDrag && !IsSingle)
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
            Debug.Log("Mtnuma");
            HitLine = true;
            cantDrag = true;
            if (!IsSingle)
            {
                Transform playerLineHit = lastRectTransform;
                Vector2 direction = (playerLineHit.position - transform.position).normalized;
                rb.AddForce(-direction * force);
            }
            HitCounter++;
            if (HitCounter < 3)
            {
                StartCoroutine(WaitToStop());
            }

        }
    }
    
    public IEnumerator Hide()
    {
        HitCounter = 0;
        yield return new WaitForSeconds(2f);

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
        PlayerTwoTurn = false;
        if (!_playersPoints.GameEnds)
        {
            playerOne.SetActive(true);
            playerOnePins.SetActive(true);
            for(int i = 0; i < PinsPlOne.Length; i++)
            {
                PinsPlOne[i].SetActive(true);
            }
            _dragItemsPlOne.PlayerOneTurn = true;
            _dragItemsPlOne.StartNewGame = true;
        }
    }
  
    public IEnumerator WaitToStop()
    {
        yield return new WaitForSeconds(6);
        rectTransform.position = startTransform.position;
        rb.velocity = Vector2.zero;
        AddPoints = true;
        cantDrag = false;
        HitLine = false;
        StartCoroutine(Position());
        if (IsSingle && HitCounter < 2)
        {
            StartCoroutine(Single());
        }
        if (HitCounter == 2)
        {
            HitCounter++;
        }
    }
}
