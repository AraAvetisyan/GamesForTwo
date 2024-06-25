using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightsScript : MonoBehaviour
{
    public bool StartGame;
    [SerializeField] private RacingButtonsHold _playerOneRacingButtonHold, _playerTwoRacingButtonHold;
    [SerializeField] private GameObject light1, light2, light3, light4, light5;
    public int Counter;
    private float timerToClose;
    public bool CanHoldOff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerOneRacingButtonHold.PlayerOneIsHolding && _playerTwoRacingButtonHold.PlayerTwoIsHolding && !StartGame)
        {
            StartGame = true;
            StartCoroutine(WaitToLight());
        }
    }

    public IEnumerator WaitToLight()
    {
        Counter++;
        if (Counter == 1)
        {
            light1.SetActive(true);
        }
        if (Counter == 2)
        {
            light2.SetActive(true);
        }
        if (Counter == 3)
        {
            light3.SetActive(true);
        }
        if(Counter == 4)
        {
            light4.SetActive(true);
        }
        if (Counter == 5)
        {
            light5.SetActive(true);
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
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        light4.SetActive(false);
        light5.SetActive(false);
        CanHoldOff = true;
    }
}
