using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.AudioSettings;

public class GreenBallGameUIController : MonoBehaviour
{
    public bool Single;
    [SerializeField] private GameObject redBallPrefab, blueBallPrefab;
    [SerializeField] private Transform redBallSpawnPoint, blueBallSpawnPoint;
    public bool RedBallActive, BlueBallActive;
    [SerializeField] private GameObject activatorPlOneGreen, activatorPlOneRed, activatorPlTwoGreen, activatorPlTwoRed;
    [SerializeField] private RotatePlayers _rotatePlayers;
    [SerializeField] private float shootingForce;
    public bool IsMobile;
    [SerializeField] private FirstPlayerZoneTrigger _firstPlayerZoneTrigger;
    [SerializeField] private SecondPlayerZoneTrigger _secondPlayerZoneTrigger;
    [SerializeField] private EndGameScript _endGameScript;
    [SerializeField] private GameObject buttonOne, buttonTwo;
    public bool IsSingle;

    float randomTimer;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
            if (!IsSingle)
            {
                buttonOne.SetActive(true);
                buttonTwo.SetActive(true);
            }
        }
        else
        {
            IsMobile = false; 
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
        }
    }
    private void Start()
    {
        if (Single)
        {
            StartCoroutine(SinglePlayer());
        }
       
    }
    private void Update()
    {
        if (_endGameScript.GameEnds)
        {
            _rotatePlayers.PlayerOneRotationSpeed = 0;
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.Z))
        {
            PressedRedButton();
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !Single)
        {
            PressedBlueButton();
        }
        if (BlueBallActive)
        {
            activatorPlOneGreen.SetActive(false);
            activatorPlOneRed.SetActive(true);
        }
        else
        {
            activatorPlOneGreen.SetActive(true);
            activatorPlOneRed.SetActive(false);
        }

        if (RedBallActive)
        {
            activatorPlTwoGreen.SetActive(false);
            activatorPlTwoRed.SetActive(true);
        }
        else
        {
            activatorPlTwoGreen.SetActive(true);
            activatorPlTwoRed.SetActive(false);
        }
    }


    public IEnumerator SinglePlayer()
    {
        randomTimer = Random.Range(0.55f, 0.7f);
        yield return new WaitForSeconds(randomTimer);
        if (!BlueBallActive)
        {
            PressedBlueButton();
        }
    }
    public void PressedBlueButton()
    {
        if (!BlueBallActive && _firstPlayerZoneTrigger.CanFireRed && _secondPlayerZoneTrigger.CanFireRed)
        {
            float z = Random.Range(0, 360);
            GameObject ball = Instantiate(blueBallPrefab, blueBallSpawnPoint.position, Quaternion.Euler(0, 0, z));
            Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            Vector2 shootingDirection = -blueBallSpawnPoint.right;
            ballRigidbody.AddForce(shootingDirection * shootingForce, ForceMode2D.Impulse);
            _rotatePlayers.PlayerOneRotationSpeed = 0;
            StartCoroutine(StopPlayerOne());
            BlueBallActive = true;
        }
    }
    public void PressedRedButton() 
    {
        if(!RedBallActive && _firstPlayerZoneTrigger.CanFireRed && _secondPlayerZoneTrigger.CanFireRed)
        {
            float z = Random.Range(0, 360);
            GameObject ball = Instantiate(redBallPrefab, redBallSpawnPoint.position, Quaternion.Euler(0, 0, z));
            Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            Vector2 shootingDirection = redBallSpawnPoint.right;
            ballRigidbody.AddForce(shootingDirection * shootingForce, ForceMode2D.Impulse);
            _rotatePlayers.PlayerTwoRotationSpeed = 0;
            StartCoroutine(StopPlayerTwo());
            RedBallActive = true;
        }
    }
    public IEnumerator StopPlayerOne()
    {
        yield return new WaitForSeconds(1);
      
        _rotatePlayers.PlayerOneRotationSpeed = 300;
        
    }
    public IEnumerator StopPlayerTwo()
    {
        yield return new WaitForSeconds(1);
       
        _rotatePlayers.PlayerTwoRotationSpeed = 300;
        
    }

    public void PresedFinishHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRestart()
    {
        if (!Single)
        {
            SceneManager.LoadScene("GreenBall");
        }
        if (Single)
        {
            SceneManager.LoadScene("GreenBallSingle");
        }
    }


}
