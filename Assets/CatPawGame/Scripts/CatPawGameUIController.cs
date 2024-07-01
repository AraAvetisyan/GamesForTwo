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
    private bool isMobile;
    [SerializeField] private bool isSingle;
    float randomTimer;
    [SerializeField] private PlayerOneScript _playerOneScript;
    [SerializeField] private PlayerTwoScript _playerTwoScript;
    [SerializeField] private CatPawEndGameManager _catPawEndGameManager;
    [SerializeField] private GameObject playerOneButton, playerTwoButton;
    private void Start()
    {
        if (isSingle)
        {
            StartCoroutine(SinglePlayer());
        }
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
            if (!isSingle)
            {
                playerOneButton.SetActive(false);
                playerTwoButton.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (!isMobile && Input.GetKeyDown(KeyCode.Z))
        {
            PressedPlayerTwoButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && !isSingle)
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
        if (!isSingle)
        {
            SceneManager.LoadScene("CatPaw");

        }
        if (isSingle)
        {
            SceneManager.LoadScene("CatPawSingle");
        }
    }
}
