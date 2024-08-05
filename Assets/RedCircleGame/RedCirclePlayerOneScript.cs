using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedCirclePlayerOneScript : MonoBehaviour
{
    public bool Pressed;
    public CircleCollider2D PlayerCollider2D;
    private int inWrongTrigger;
    [SerializeField] private CircularMotion _circularMotion;
    [SerializeField] private PlayerOneCircleChanger _playerOneCircleChanger;
    public int Points;
    private int pointsBuffer;
    [SerializeField] private TextMeshProUGUI pointsText;
    private bool inCircle;
    private bool inWrongCircle;
    [SerializeField] private RedCircleUIController _redCircleUIController;
    [SerializeField] private GameObject rightTrigger, wrongTrigger;
    private void Start()
    {
        if(_redCircleUIController.IsMobile && !_redCircleUIController.IsSingle)
        {
            pointsText.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if(!_redCircleUIController.IsMobile || _redCircleUIController.IsSingle) 
        {
            pointsText.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            inCircle = true;
            StartCoroutine(ChangeInCircle());
        }
        else if (collision.CompareTag("NotTrigger"))
        {
            if (!inCircle)
            {
                inWrongCircle = true;
                StartCoroutine(WaitToWrong());
            }
        }
    }
    public IEnumerator ChangeInCircle()
    {
        Points++;
        GameObject sound = Instantiate(rightTrigger);
        Destroy(sound, 1f);
        pointsText.text = Points.ToString();
        _playerOneCircleChanger.ChangePlOneCircle();
        Pressed = false;
        PlayerCollider2D.enabled = false;
        yield return new WaitForSeconds(0.05f);
        inCircle = false;

    }
    public IEnumerator WaitToWrong()
    {

        if (!inCircle)
        {
            _circularMotion.Speed = 0;
            GameObject wrongSound = Instantiate(wrongTrigger);
            Destroy(wrongSound, 1f);
            Pressed = false;
            PlayerCollider2D.enabled = false;
            yield return new WaitForSeconds(1f);
            _circularMotion.Speed = 5;
            inWrongCircle = false;
        }
    }
}

