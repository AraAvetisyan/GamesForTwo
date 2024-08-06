using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RedCirclePlayerTwoScript : MonoBehaviour
{

    public bool Pressed;
    [SerializeField] private CircularMotion _circularMotion;
    [SerializeField] private PlayerTwoCircleChanger _playerTwoCircleChanger;
    public int Points;
    [SerializeField] private TextMeshProUGUI pointsText;
    public bool inCircle;
    public bool inWrongCircle;
    [SerializeField] private GameObject rightTrigger, wrongTrigger;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Trigger"))
        {
            inCircle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            inCircle = false;
        }
    }
    public IEnumerator ChangeInCircle()
    {
        GameObject sound = Instantiate(rightTrigger);
        Destroy(sound, 1f);
        Points++;
        pointsText.text = Points.ToString();
        _playerTwoCircleChanger.ChangePlTwoCircle();
        Pressed = false;
        yield return new WaitForSeconds(0.05f);
        inCircle = false;

    }
    public IEnumerator WaitToWrong()
    {

        GameObject wrongSound = Instantiate(wrongTrigger);
        Destroy(wrongSound, 1f);
        _circularMotion.Speed = 0;
        Pressed = false;
        yield return new WaitForSeconds(1f);
        _circularMotion.Speed = 5;
        inWrongCircle = false;

    }
}



