using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedCirclePlayerTwoScript : MonoBehaviour
{

    public bool Pressed;
    public CircleCollider2D PlayerCollider2D;
    private int inWrongTrigger;
    [SerializeField] private CircularMotion _circularMotion;
    [SerializeField] private PlayerTwoCircleChanger _playerTwoCircleChanger;
    public int Points;
    //private int pointsBuffer;
    [SerializeField] private TextMeshProUGUI pointsText;
    private bool inCircle;
    private void Update()
    {
        if (inWrongTrigger == 1)
        {
            _circularMotion.Speed = 0;
            inWrongTrigger = 0;
            StartCoroutine(WaitToWrong());
        }
    }
    public IEnumerator WaitToWrong()
    {
        yield return new WaitForSeconds(1.5f);
        _circularMotion.Speed = 5;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            inCircle = true;
            Points++;
            //pointsBuffer++;

            //Debug.Log("Qanaky - " + pointsBuffer);
            //if (pointsBuffer == 1)
            //{
            //    Points += 1;
            //}
            //if (pointsBuffer == 2)
            //{
            //    Points += 2;
            //}
            //if (pointsBuffer == 3)
            //{
            //    Points += 3;
            //}
            //if (pointsBuffer == 4)
            //{
            //    Points += 4;
            //}
            //if (pointsBuffer == 5)
            //{
            //    Points += 5;
            //}

            pointsText.text = Points.ToString();
            _playerTwoCircleChanger.ChangePlTwoCircle();
            Pressed = false;
            PlayerCollider2D.enabled = false;
            StartCoroutine(ChangeInCircle());
        }
        if (collision.gameObject.tag == "NotTrigger" && !inCircle)
        {
            //pointsBuffer = 0;
            Pressed = false;
            PlayerCollider2D.enabled = false;
            inWrongTrigger = 1;
        }
    }
    public IEnumerator ChangeInCircle()
    {
        yield return new WaitForSeconds(0.25f);
        inCircle = false;

    }
}
