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
                playerOneButton.SetActive(false);
                playerTwoButton.SetActive(false);
            }
        }
    }
    private void Start()
    {
        if (IsSingle)
        {
            StartCoroutine(SinglePlayer());
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
            StartCoroutine(WaitToGoBack());
            playerOnePaw.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (ButtonTwoPressed)
        {

            StartCoroutine(WaitToGoBack());
            playerTwoPaw.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        //if(!buttonOnePressed)
        //{
        //   
        //}
        //if (!buttonTwoPressed)
        //{
        //    
        //}

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
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRestButton()
    {
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
