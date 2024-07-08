using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private JoystickPlayerExample _joystickPlayerExample;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light" && this.gameObject.tag != "Guard")
        {
            Debug.Log("Mtav");
            _joystickPlayerExample.speed = _joystickPlayerExample.speed / 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light" && this.gameObject.tag != "Guard")
        {
            _joystickPlayerExample.speed = _joystickPlayerExample.speed * 2;
        }
    }
}
