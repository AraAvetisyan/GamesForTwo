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
    [SerializeField]
    private AudioSource buttonSound;
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
            PressedPlayerTwoButton();
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !IsSingle)
        {
            PressedPlayerOneButton();
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
            playerOnePaw.transform.Translate(Vector3.down * speed * Time.deltaTime);
            playerOnePaw.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (ButtonTwoPressed)
        {

          //  StartCoroutine(WaitToGoBack());
            playerTwoPaw.transform.Translate(Vector3.up * speed * Time.deltaTime);
            playerTwoPaw.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (!ButtonOnePressed)
        {
            playerOnePaw.transform.position = playerOnePosition.position;
        }
        if(!ButtonTwoPressed)
        {
            playerTwoPaw.transform.position = playerTwoPosition.position;
        }
    }
    public IEnumerator WaitToGoBack()
    {
        yield return new WaitForSecondsRealtime(Timer);
        playerOnePaw.transform.position = playerOnePosition.position;
        playerTwoPaw.transform.position = playerTwoPosition.position;
        ButtonTwoPressed = false;
        ButtonOnePressed = false;
    }

    public void PressedHomeButton()
    {

        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedRestButton()
    {

        buttonSound.Play();
        if (!IsSingle)
        {
            SceneManager.LoadScene("CatPaw");

        }
        if (IsSingle)
        {
            SceneManager.LoadScene("CatPawSingle");
        }
        Geekplay.Instance.ShowInterstitialAd();
    }
}
