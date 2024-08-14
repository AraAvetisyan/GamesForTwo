using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatPawGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject playerOnePaw, playerTwoPaw;
    [SerializeField] private float speed;
    public bool ButtonOnePressed, ButtonTwoPressed;
    [SerializeField] private Transform playerOnePosition, playerTwoPosition;
    public float Timer;
    public bool IsMobile;
    public bool IsSingle;
    float randomTimer;
    [SerializeField] private PlayerOneScript _playerOneScript;
    [SerializeField] private PlayerTwoScript _playerTwoScript;
    [SerializeField] private CatPawEndGameManager _catPawEndGameManager;
    [SerializeField] private GameObject playerOneButton, playerTwoButton;
    [SerializeField] private GameObject buttonBG;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private Transform targetPositionPlOne, targetPositionPlTwo;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false; 
            playerOneButton.SetActive(false);
            playerTwoButton.SetActive(false);
            buttonBG.SetActive(false);
           
        }

    }
    private void Start()
    {
        if (IsSingle)
        {
            StartCoroutine(SinglePlayer());
        }
        if (IsSingle)
        {

            playerOneButton.SetActive(false);
        }
        
    }
    private void Update()
    {
        if (!IsMobile && Input.GetKeyDown(KeyCode.Z))
        {
            if (!_playerTwoScript.CantPlay && !_catPawEndGameManager.PlTwoCantPlay)
            {
                PressedPlayerTwoButton();
            }
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !IsSingle)
        {
            if (!_playerOneScript.CantPlay && !_catPawEndGameManager.PlOneCantPlay)
            {
                PressedPlayerOneButton();
            }
        }
    }
    public IEnumerator SinglePlayer()
    {
        randomTimer = Random.Range(2f, 3f);
        yield return new WaitForSeconds(randomTimer);
        PressedPlayerOneButton();
        StartCoroutine(SinglePlayer());
    }
    public void PressedPlayerOneButton()
    {
        if (!_playerOneScript.CantPlay && !_catPawEndGameManager.PlOneCantPlay)
        {
            ButtonOnePressed = true;
        }

    }
    public void PressedPlayerTwoButton()
    {
        if (!_playerTwoScript.CantPlay && !_catPawEndGameManager.PlTwoCantPlay)
        {
            ButtonTwoPressed = true;
        }
    }


    private void FixedUpdate()
    {
        if (ButtonOnePressed)
        {
            //StartCoroutine(WaitToGoBack());
            //playerOnePaw.transform.Translate(Vector3.down * speed * Time.deltaTime);
            //  playerOnePaw.transform.Translate(Vector3.left * speed * Time.deltaTime);
          //  Vector3 dir = (playerOnePaw.transform.position - targetPosition.position).normalized;
            playerOnePaw.transform.DOMoveX(targetPositionPlOne.position.x, speed);
            playerOnePaw.transform.DOMoveY(targetPositionPlOne.position.y, speed);
        }
        if (ButtonTwoPressed)
        {

            //  StartCoroutine(WaitToGoBack());
            // playerTwoPaw.transform.Translate(Vector3.up * speed * Time.deltaTime);
            //  playerTwoPaw.transform.Translate(Vector3.right * speed * Time.deltaTime);
            playerTwoPaw.transform.DOMoveX(targetPositionPlTwo.position.x, speed);
            playerTwoPaw.transform.DOMoveY(targetPositionPlTwo.position.y, speed);
        }
        if (!ButtonOnePressed)
        {
            // playerOnePaw.transform.position = playerOnePosition.position;
            playerOnePaw.transform.DOMoveX(playerOnePosition.position.x, speed);
            playerOnePaw.transform.DOMoveY(playerOnePosition.position.y, speed);
        }
        if(!ButtonTwoPressed)
        {
           // playerTwoPaw.transform.position = playerTwoPosition.position;
            playerTwoPaw.transform.DOMoveX(playerTwoPosition.position.x, speed);
            playerTwoPaw.transform.DOMoveY(playerTwoPosition.position.y, speed);
        }
    }


    public void PressedHomeButton()
    {

        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRestButton()
    {

        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
        if (!IsSingle)
        {
            SceneManager.LoadScene("CatPaw");

        }
        if (IsSingle)
        {
            SceneManager.LoadScene("CatPawSingle");
        }
    }
}
