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
    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
            Debug.Log("IsMobile");
        }
        else
        {
            isMobile = false;
        }
    }
    private void Update()
    {
        if (!isMobile && Input.GetKeyDown(KeyCode.Z))
        {
            PressedPlayerTwoButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M))
        {
            PressedPlayerOneButton();
        }
    }
    public void PressedPlayerOneButton()
    {
        ButtonOnePressed = true;

    }
    public void PressedPlayerTwoButton() 
    {
        ButtonTwoPressed = true;
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
        SceneManager.LoadScene("CatPaw");
    }
}
