
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightsScript : MonoBehaviour
{
    public bool StartGame;
    [SerializeField] private RacingButtonsHold _playerOneRacingButtonHold, _playerTwoRacingButtonHold;
    public GameObject Light1, Light2, Light3, Light4, Light5;
    public GameObject GreenLight1, GreenLight2, GreenLight3, GreenLight4, GreenLight5;
    public int Counter;
    private float timerToClose;
    public bool CanHoldOff;
    public bool BothSoon;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerOneRacingButtonHold.PlayerOneIsHolding && _playerTwoRacingButtonHold.PlayerTwoIsHolding && !StartGame && !BothSoon)
        {
            StartGame = true;
            StartCoroutine(WaitToLight());
        }
        if (BothSoon)
        {
            StopAllCoroutines();
            StartGame = false;
            Light1.SetActive(false);
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);            
            Light5.SetActive(false);
            BothSoon = false;
        }
    }

    public IEnumerator WaitToLight()
    {
        Counter++;
        if (Counter == 1)
        {
            Light1.SetActive(true);
        }
        if (Counter == 2)
        {
            Light2.SetActive(true);
        }
        if (Counter == 3)
        {
            Light3.SetActive(true);
        }
        if (Counter == 4)
        {
            Light4.SetActive(true);
        }
        if (Counter == 5)
        {
            Light5.SetActive(true);
        }
        yield return new WaitForSecondsRealtime(1f);
        if (Counter <= 5)
        {
            StartCoroutine(WaitToLight());
        }
        else
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        timerToClose = Random.Range(0, 3.5f);
        StartCoroutine(WaitToTimer());
    }

    public IEnumerator WaitToTimer()
    {
        yield return new WaitForSecondsRealtime(timerToClose);
        Light1.SetActive(false);
        Light2.SetActive(false);
        Light3.SetActive(false);
        Light4.SetActive(false);
        Light5.SetActive(false);
        GreenLight1.SetActive(true);
        GreenLight2.SetActive(true);
        GreenLight3.SetActive(true);
        GreenLight4.SetActive(true);
        GreenLight5.SetActive(true);
        CanHoldOff = true;
    }
   
       
   
}
