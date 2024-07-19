using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public FloatingJoystick FloatingJoystick;
    public Rigidbody2D rb;
    [SerializeField] GuardTimer _guardTimer;
    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject joysticplOne, joysticplTwo;

    [SerializeField] private Transform[] singlePoints;
    private int pointInd;
    private void Start()
    {
        if (!_guardTimer.IsMobile)
        {
            joysticplOne.SetActive(false);
            joysticplTwo.SetActive(false);
           
        }
        if (_guardTimer.IsSingle)
        {
            joysticplTwo.SetActive(false);
            if(playerIndex == 2)
            {
                StartCoroutine(Single());
            }
        }
    }
    public void FixedUpdate()
    {
        if (_guardTimer.IsMobile)
        {

            rb.velocity = new Vector2(FloatingJoystick.Horizontal * speed, FloatingJoystick.Vertical * speed);
            float angle = Mathf.Atan2(-FloatingJoystick.Vertical, -FloatingJoystick.Horizontal) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));


        }
        else
        {
            if (playerIndex == 1)
            {
                //float h = Input.GetAxis("Horizontal");
                //float v = Input.GetAxis("Vertical");
                float h = 0;
                float v = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    v = (Vector2.up * speed).y;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    v = -(Vector2.up * speed).y;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    h = -(Vector2.right * speed).x;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    h = (Vector2.right * speed).x;
                }
                Vector2 moveDirection = new Vector2(h, v);
                float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
                moveDirection.Normalize();

                transform.Translate(moveDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
                if (moveDirection != Vector2.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
                }

            }
            if (playerIndex == 2 && !_guardTimer.IsSingle)
            {
                float h2 = 0;
                float v2 = 0;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    v2 = (Vector2.up * speed).y;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    v2 = -(Vector2.up * speed).y;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    h2 = -(Vector2.right * speed).x;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    h2 = (Vector2.right * speed).x;
                }
                Vector2 moveDirection = new Vector2(h2, v2);
                float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
                moveDirection.Normalize();

                transform.Translate(moveDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
                if (moveDirection != Vector2.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
                }
            }
            if (playerIndex == 2 && _guardTimer.IsSingle)
            {
                Vector2 moveDirection = (singlePoints[pointInd].position - transform.position).normalized; 
                transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
                if(transform.position.x == moveDirection.x || transform.position.y == moveDirection.y)
                {
                    pointInd = Random.Range(0, singlePoints.Length);
                }
                if (moveDirection != Vector2.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
                }
            }
        }
    }
    public IEnumerator Single()
    {
        pointInd = Random.Range(0,singlePoints.Length);        
        yield return new WaitForSecondsRealtime(2f);
        StartCoroutine(Single());
    }
}
