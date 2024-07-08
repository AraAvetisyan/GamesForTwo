using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTrigger : MonoBehaviour
{
    public bool GuardWin;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Robber")
        {
            GuardWin = true;
        }
    }
}
