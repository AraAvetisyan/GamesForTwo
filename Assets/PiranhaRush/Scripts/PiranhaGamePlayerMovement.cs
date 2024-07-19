using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AudioSettings;

public class PiranhaGamePlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public FloatingJoystick FloatingJoystick;
    public Rigidbody2D rb;
    [SerializeField] private int playerIndex;
    public bool IsMobile;
    [SerializeField] private GameObject joysticPlayerOne, joysticPlayerTwo;


    public bool IsSingle;
    [SerializeField] private Transform[] singlePath1, singlePath2, singlePath3;
    [SerializeField] private GameObject singlePath1Object, singlePath2Object, singlePath3Object;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private int pathCounter;
    [SerializeField] private int pathInt;
    [SerializeField] private GameObject playerTwoObject;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
        }
    }
    private void Start()
    {
        if (playerIndex == 2 && IsSingle)
        {
            pathCounter = Random.Range(0, 3);
            if(pathCounter == 0)
            {
                targetTransform = singlePath1[pathInt];
                singlePath1Object.SetActive(true);
            }
            if(pathCounter == 1)
            {
                targetTransform = singlePath2[pathInt];
                singlePath2Object.SetActive(true);
            }
            if (pathCounter == 2)
            {
                targetTransform = singlePath3[pathInt];
                singlePath3Object.SetActive(true);
            }
        }
        if (!IsMobile)
        {
            joysticPlayerOne.SetActive(false);
            joysticPlayerTwo.SetActive(false);
        }
        if(IsMobile && IsSingle)
        {

            joysticPlayerTwo.SetActive(false);
        }
    }
    public void FixedUpdate()
    {

        if (IsMobile)
        {
            if (playerIndex == 1)
            {
                float jh = 0;
                float jv = 0;
                jh = FloatingJoystick.Horizontal;
                jv = FloatingJoystick.Vertical;
                Vector2 joysticMoveDirection = new Vector2(jh, jv);
                float joysticInputMagnitude = Mathf.Clamp01(joysticMoveDirection.magnitude);
                joysticMoveDirection.Normalize();
                transform.Translate(joysticMoveDirection * speed * joysticInputMagnitude * Time.deltaTime, Space.World);
                float angle = Mathf.Atan2(-FloatingJoystick.Vertical, -FloatingJoystick.Horizontal) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            }
            if (playerIndex == 2 && !IsSingle)
            {
                float jh = 0;
                float jv = 0;
                jh = FloatingJoystick.Horizontal;
                jv = FloatingJoystick.Vertical;
                Vector2 joysticMoveDirection = new Vector2(jh, jv);
                float joysticInputMagnitude = Mathf.Clamp01(joysticMoveDirection.magnitude);
                joysticMoveDirection.Normalize();
                transform.Translate(joysticMoveDirection * speed * joysticInputMagnitude * Time.deltaTime, Space.World);
                float angle = Mathf.Atan2(-FloatingJoystick.Vertical, -FloatingJoystick.Horizontal) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            }
            if (playerIndex == 2 && IsSingle)
            {
                Debug.Log("GARUN");
                Vector2 moveDirection = (targetTransform.position - transform.position).normalized;

                playerTwoObject.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

                if (moveDirection != Vector2.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                    playerTwoObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
                }

            }

        }
        else
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
            if (playerIndex == 2 && !IsSingle)
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
            if (playerIndex == 2 && IsSingle)
            {
                Debug.Log("GARUN");
                Vector2 moveDirection = (targetTransform.position - transform.position).normalized;

                playerTwoObject.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

                if (moveDirection != Vector2.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                    playerTwoObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerIndex == 2 && IsSingle)
        {
            if (collision.gameObject.tag == "Path")
            {
                // singlePath1.RemoveAt(pathInt);
                //Destroy(collision.gameObject);
                pathInt++;
                if (pathCounter == 0)
                {
                    targetTransform = singlePath1[pathInt];
                }
                if (pathCounter == 1)
                {
                    targetTransform = singlePath2[pathInt];
                }
                if (pathCounter == 2)
                {
                    targetTransform = singlePath3[pathInt];
                }
            }
        }
    }

}
