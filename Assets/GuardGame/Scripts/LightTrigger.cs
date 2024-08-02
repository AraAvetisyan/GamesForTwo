using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private JoystickPlayerExample _joystickPlayerExample;
    [SerializeField] private AudioSource lightAudio;
    private int soundCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light" && this.gameObject.tag != "Guard")
        {
            _joystickPlayerExample.speed = _joystickPlayerExample.speed / 2;
            if(soundCounter == 0)
            {
                soundCounter = 1;
                lightAudio.Play();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light" && this.gameObject.tag != "Guard")
        {
            soundCounter = 0;
            lightAudio.Stop();
            _joystickPlayerExample.speed = _joystickPlayerExample.speed * 2;
        }
    }
}
