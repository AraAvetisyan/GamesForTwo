
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SummoGameScriptPlOne : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotatePlayers _rotatePlayers;
    public int PlayerIndex;
    [SerializeField] private float speed;
    [SerializeField] private GameObject PlayerOne;

    public bool PlayerOneIsHolding;

    public bool GameEnds;

    public bool IsMobile;
    public bool IsSingle;

    [SerializeField] private float first, second;
    [SerializeField] private Image buttonOneBg;
    [SerializeField] private Image buttonOne;

    [SerializeField] private Rigidbody2D rbPlOne;
    [SerializeField] private Transform plOneTransform;

    public GameObject PlOneIdle, PlOneRunning;
    [SerializeField] private GameObject buttonBackground;
    //public bool Fall;

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
            Color color = buttonOneBg.color;
            color.a = 0.0001f; // Óñòàíîâèòå æåëàåìîå çíà÷åíèå àëüôà-êàíàëà (îò 0.0 äî 1.0)
            buttonOneBg.color = color;

            buttonOne.color = color;
            if (!IsSingle)
            {


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


        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !IsSingle && !GameEnds)
        {
            PlayerOneIsHolding = true;
        }

        if (!IsMobile && Input.GetKeyUp(KeyCode.M) && !IsSingle)
        {
            PlayerOneIsHolding = false;
            _rotatePlayers.PlayerOneRotationSpeed = 300f;
        }


        if (PlayerOneIsHolding)
        {
            PlOneIdle.SetActive(false);
            PlOneRunning.SetActive(true);

            rbPlOne.freezeRotation = true;
            Vector2 dir = plOneTransform.right;
            rbPlOne.velocity = -dir * speed * Time.deltaTime;
            _rotatePlayers.PlayerOneRotationSpeed = 0;
        }

        if (!PlayerOneIsHolding)
        {
            PlOneIdle.SetActive(true);
            PlOneRunning.SetActive(false);
            // Debug.Log("!PlayerOneIsHolding");
            rbPlOne.velocity = Vector2.zero;
        }





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
        if (PlayerIndex == 1)
        {
            PlayerOneIsHolding = false;
            rbPlOne.freezeRotation = false;
            _rotatePlayers.PlayerOneRotationSpeed = 300f;
        }

    }

    public IEnumerator Single()
    {
        float timer = Random.Range(first, second);
        PlayerOneIsHolding = true;
        yield return new WaitForSeconds(timer);
        yield return new WaitForSeconds(.25f);
        PlayerOneIsHolding = false;
        _rotatePlayers.PlayerOneRotationSpeed = 300f;
    }
}
