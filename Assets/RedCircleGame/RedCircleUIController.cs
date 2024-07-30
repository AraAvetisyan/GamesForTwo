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
    [SerializeField] private GameObject buttonBG;
    public bool IsSingle;
    private bool canPlay;
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
            buttonBG.SetActive(false);
        }
    }
   
    private void OnEnable()
    {
        RedCircleStartScript.RedCircleGameStarts += GameStarts;
    }
    private void OnDisable()
    {
        RedCircleStartScript.RedCircleGameStarts -= GameStarts;
    }
    public void GameStarts(int i)
    {
        if (IsSingle)
        {
            StartCoroutine(Single());
        }
        canPlay = true;
    }
    private void Update()
    {
        if (canPlay)
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
        Geekplay.Instance.ShowInterstitialAd();
    }
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
        Geekplay.Instance.ShowInterstitialAd();
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
