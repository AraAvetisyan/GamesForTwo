using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedCircleUIController : MonoBehaviour
{
    [SerializeField] RedCirclePlayerOneScript _redCirclePlayerOneScript;
    [SerializeField] RedCirclePlayerTwoScript _redCirclePlayerTwoScript;
    private bool isMobile;
    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
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
            PressedPlayerOneButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M))
        {
            PressedPlayerTwoButton();
        }
    }
    public void PressedRest()
    {
        SceneManager.LoadScene("RedCircle");
    }
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedPlayerOneButton()
    {
        _redCirclePlayerOneScript.PlayerCollider2D.enabled = true;
        _redCirclePlayerOneScript.Pressed = true;
    }
    public void PressedPlayerTwoButton()
    {
        _redCirclePlayerTwoScript.PlayerCollider2D.enabled = true;
        _redCirclePlayerTwoScript.Pressed = true;
    }
}
