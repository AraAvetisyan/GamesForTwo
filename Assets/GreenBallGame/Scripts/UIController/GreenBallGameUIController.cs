using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.AudioSettings;

public class GreenBallGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject redBallPrefab, blueBallPrefab;
    [SerializeField] private Transform redBallSpawnPoint, blueBallSpawnPoint;
    public bool RedBallActive, BlueBallActive;
    [SerializeField] private GameObject activatorPlOneGreen, activatorPlOneRed, activatorPlTwoGreen, activatorPlTwoRed;
    [SerializeField] private RotatePlayers _rotatePlayers;
    [SerializeField] private float shootingForce;
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
            PressedRedButton();
        }
        if (!isMobile && Input.GetKeyDown(KeyCode.M))
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
    public void PressedBlueButton()
    {
        if (!BlueBallActive)
        {
            GameObject ball = Instantiate(blueBallPrefab, blueBallSpawnPoint.position, Quaternion.identity);
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
        if(!RedBallActive)
        {
            GameObject ball = Instantiate(redBallPrefab, redBallSpawnPoint.position, Quaternion.identity);
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
        SceneManager.LoadScene("GreenBall");
    }


}
