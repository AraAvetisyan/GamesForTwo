
using System;
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
    [SerializeField] private AudioSource buttonSound;
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
    private void Start()
    {
        
        Geekplay.Instance.GameReady();
        
        if (IsSingle)
        {
            StartCoroutine(Single());
            plOneButton.SetActive(false);
        }
    }
    private void Update()
    {
        if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && !IsSingle)
        {
            PressedPlayerTwoButton();
        }

        if (!IsMobile && Input.GetKeyDown(KeyCode.Space) && IsSingle)
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
        buttonSound.Play();
        Geekplay.Instance.ShowInterstitialAd();
     
        StartCoroutine(WaitForAdd());
    }
    public IEnumerator WaitForAdd()
    {
        yield return new WaitForSeconds(0.1f);
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
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedPlayerOneButton()
    {
        _redCirclePlayerOneScript.Pressed = true;

        if (_redCirclePlayerOneScript.inCircle)
        {
            StartCoroutine(_redCirclePlayerOneScript.ChangeInCircle());
        }
        else
        {
            StartCoroutine(_redCirclePlayerOneScript.WaitToWrong());
        }
    }
    public void PressedPlayerTwoButton()
    {
        _redCirclePlayerTwoScript.Pressed = true;
        
        if (_redCirclePlayerTwoScript.inCircle)
        {
            StartCoroutine(_redCirclePlayerTwoScript.ChangeInCircle());
        }
        else
        {
            StartCoroutine(_redCirclePlayerTwoScript.WaitToWrong());
        }
    }

    public IEnumerator Single()
    {

        float timer = UnityEngine.Random.Range(0.1f, 2f);
        yield return new WaitForSeconds(timer);

        PressedPlayerOneButton();

        StartCoroutine(Single());

    }
}
