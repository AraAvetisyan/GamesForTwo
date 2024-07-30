using System;
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
    private Transform targetTransform;
    private bool canSinglStart;
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
           
        }       
    }
    private void OnEnable()
    {
        GuardGameStartScript.StartGuardGame += StartGame;
    }
    private void OnDisable()
    {
        GuardGameStartScript.StartGuardGame -= StartGame;
    }
    public void StartGame(int j)
    {
        if (_guardTimer.IsSingle)
        {
            joysticplTwo.SetActive(false);
            if (playerIndex == 2)
            {
                for (int i = 0; i < singlePoints.Length; i++)
                {
                    singlePoints[i].GetComponent<BoxCollider2D>().enabled = false;
                    if (i == singlePoints.Length - 1)
                    {
                        StartCoroutine(Single());
                    }
                }
            }
        }
        canSinglStart = true;
    }
    public void FixedUpdate()
    {
        if (_guardTimer.IsMobile && _guardTimer.IsSingle)       //mobile single game
        {
            if (playerIndex == 1)
            {
                rb.velocity = new Vector2(FloatingJoystick.Horizontal * speed, FloatingJoystick.Vertical * speed);
                float angle = Mathf.Atan2(-FloatingJoystick.Vertical, -FloatingJoystick.Horizontal) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

            }
            if (playerIndex == 2)
            {
                if (canSinglStart)
                {
                    Vector2 moveDirection = (singlePoints[pointInd].position - transform.position).normalized;
                    transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

                    if (moveDirection != Vector2.zero)
                    {
                        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
                    }
                }
            }
        } // end

        if (_guardTimer.IsMobile && !_guardTimer.IsSingle)  //mobile multyplay game
        {

            rb.velocity = new Vector2(FloatingJoystick.Horizontal * speed, FloatingJoystick.Vertical * speed);
            float angle = Mathf.Atan2(-FloatingJoystick.Vertical, -FloatingJoystick.Horizontal) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        }// end


        if (!_guardTimer.IsMobile && !_guardTimer.IsSingle) //pc multyplay game
        {
            if (playerIndex == 1)
            {
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
            if (playerIndex == 2)
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
        } // end

        if(!_guardTimer.IsMobile && _guardTimer.IsSingle) // pc single game
        {
            if (playerIndex == 1)
            {
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
            if (playerIndex == 2)
            {
                if (canSinglStart)
                {
                    Vector2 moveDirection = (singlePoints[pointInd].position - transform.position).normalized;
                    transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

                    if (moveDirection != Vector2.zero)
                    {
                        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
                    }
                }
            }
        }//end


          
    }
    public IEnumerator Single()
    {
        pointInd = UnityEngine.Random.Range(0,singlePoints.Length);
        singlePoints[pointInd].GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSecondsRealtime(0.0001f);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerIndex == 2 && _guardTimer.IsSingle)
        {
            if (collision.CompareTag("Path"))
            {
               
                pointInd = UnityEngine.Random.Range(0, singlePoints.Length);
                for (int i = 0; i < singlePoints.Length; i++)
                {
                    singlePoints[i].GetComponent<BoxCollider2D>().enabled = false;
                    if (i == singlePoints.Length - 1)
                    {
                        singlePoints[pointInd].GetComponent<BoxCollider2D>().enabled = true;
                    }
                }
                
               // Debug.Log("in path");
            }
        }
    }
}
