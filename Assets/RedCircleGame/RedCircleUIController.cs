using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedCircleUIController : MonoBehaviour
{
    [SerializeField] RedCirclePlayerOneScript _redCirclePlayerOneScript;
    [SerializeField] RedCirclePlayerTwoScript _redCirclePlayerTwoScript;
    private bool isMobile;
    [SerializeField] private RedCircleTimer _redCircleTimer;

    [SerializeField] private bool isSingle;
    private void Start()
    {
        if (isSingle)
        {
            StartCoroutine(Single());
        }
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
            PressedPlayerTwoButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && !isSingle)
        {

            PressedPlayerOneButton();
        }
    }
    public void PressedRest()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("RedCircle");
        }
        if (isSingle)
        {
            SceneManager.LoadScene("RedCircleSingle");
        }
    }
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedPlayerOneButton()
    {
        if (!_redCircleTimer.PlOneCantPlay)
        {
            _redCirclePlayerOneScript.PlayerCollider2D.enabled = true;
            _redCirclePlayerOneScript.Pressed = true;
        }
    }
    public void PressedPlayerTwoButton()
    {
        if (!_redCircleTimer.PlTwoCantPlay)
        {
            _redCirclePlayerTwoScript.PlayerCollider2D.enabled = true;
            _redCirclePlayerTwoScript.Pressed = true;
        }
    }

    public IEnumerator Single()
    {

        float timer = Random.Range(0.1f, 2f);
        yield return new WaitForSeconds(timer);

        PressedPlayerOneButton();

        StartCoroutine(Single());

    }
}
