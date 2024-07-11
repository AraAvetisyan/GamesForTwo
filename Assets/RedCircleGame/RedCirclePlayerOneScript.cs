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
    [SerializeField] private RedCircleUIController _redCircleUIController;
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
           
            
            pointsText.text = Points.ToString();
            _playerOneCircleChanger.ChangePlOneCircle();
            Pressed = false;
            PlayerCollider2D.enabled = false;
            StartCoroutine(ChangeInCircle());
        }
        if (collision.gameObject.tag == "NotTrigger" && !inCircle)
        {
            pointsBuffer = 0;
            Pressed = false;
            PlayerCollider2D.enabled = false;
            inWrongTrigger = 1;
        }
    }
    public IEnumerator ChangeInCircle()
    {
        yield return new WaitForSeconds(1f);
        inCircle = false;
        
    }
}
