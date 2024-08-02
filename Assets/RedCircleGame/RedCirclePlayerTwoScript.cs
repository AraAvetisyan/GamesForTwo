using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RedCirclePlayerTwoScript : MonoBehaviour
{

    public bool Pressed;
    public CircleCollider2D PlayerCollider2D;
    [SerializeField] private CircularMotion _circularMotion;
    [SerializeField] private PlayerTwoCircleChanger _playerTwoCircleChanger;
    public int Points;
    //private int pointsBuffer;
    [SerializeField] private TextMeshProUGUI pointsText;
    public bool inCircle;
    public bool inWrongCircle;
    private int iswrong;
    private bool addedPoints;
    [SerializeField] private AudioSource rightTrigger, wrongTrigger;
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
        rightTrigger.Play();
        Points++;
        pointsText.text = Points.ToString();
        _playerTwoCircleChanger.ChangePlTwoCircle();
        Pressed = false;
        PlayerCollider2D.enabled = false;
        yield return new WaitForSeconds(0.05f);
        inCircle = false;

    }
    public IEnumerator WaitToWrong()
    {

        if (!inCircle)
        {
            wrongTrigger.Play();
            _circularMotion.Speed = 0;
            Pressed = false;
            PlayerCollider2D.enabled = false;
            yield return new WaitForSeconds(1f);
            _circularMotion.Speed = 5;
            inWrongCircle = false;
        }
    }
}




//private void OnTriggerEnter2D(Collider2D collision)
//{
//    if (collision.CompareTag("Trigger"))
//    {
//        inCircle = true;
//        StartCoroutine(ChangeInCircle());
//        if (!inWrongCircle)
//        {
//            _playerTwoCircleChanger.ChangePlTwoCircle();
//            Points++;
//        }
//        else
//        {
//            _playerTwoCircleChanger.ChangeToLastCircle();
//        }
//    }
//    else if (collision.CompareTag("NotTrigger"))
//    {
//        if (!inCircle)
//        {
//            inWrongCircle = true;
//            StartCoroutine(WaitToWrong());
//        }

//    }
//}
//public IEnumerator ChangeInCircle()
//{
//    pointsText.text = Points.ToString();
//    Pressed = false;
//    PlayerCollider2D.enabled = false;
//    yield return new WaitForSeconds(0.01f);
//    inCircle = false;
//}

//public IEnumerator WaitToWrong()
//{

//    if (!inCircle)
//    {
//        _circularMotion.Speed = 0;
//        Pressed = false;
//        PlayerCollider2D.enabled = false;
//        yield return new WaitForSeconds(1f);
//        _circularMotion.Speed = 5;
//        inWrongCircle = false;
//        iswrong = 0;
//    }
//}
//}