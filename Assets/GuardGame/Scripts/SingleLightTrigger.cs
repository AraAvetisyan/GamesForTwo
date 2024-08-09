using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLightTrigger : MonoBehaviour
{
    [SerializeField] JoystickPlayerExample _joystickPlayerExample;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Robber"))
        {
            _joystickPlayerExample.IsInLight = true;
        }
    }
}
