using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedCircleUIController : MonoBehaviour
{
    [SerializeField] RedCirclePlayerOneScript _redCirclePlayerOneScript;
    [SerializeField] RedCirclePlayerTwoScript _redCirclePlayerTwoScript;
    public bool IsMobile;
    [SerializeField] private RedCircleTimer _redCircleTimer;
    [SerializeField] private GameObject plOneButton, plTwoButton;
    public bool IsSingle;
    private void Awake()
    {
       
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
            plOneButton.SetActive(false);
            plTwoButton.SetActive(false);
        }
    }
    private void Start()
    {
        if (IsSingle)
        {
            StartCoroutine(Single());
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
    public void PressedRest()
    {
        if (!IsSingle)
        {
            SceneManager.LoadScene("RedCircle");
        }
        if (IsSingle)
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
