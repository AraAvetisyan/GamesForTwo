using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaGamePlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private FloatingJoystick FloatingJoystick;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int playerIndex;
    void Start()
    {
        
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(FloatingJoystick.Horizontal * speed, FloatingJoystick.Vertical * speed);
        float angle = Mathf.Atan2(-FloatingJoystick.Vertical, -FloatingJoystick.Horizontal) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));


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
    }
}
