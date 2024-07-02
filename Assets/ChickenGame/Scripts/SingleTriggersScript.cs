using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTriggersScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
