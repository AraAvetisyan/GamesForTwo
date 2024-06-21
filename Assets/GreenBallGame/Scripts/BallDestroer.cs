using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroer : MonoBehaviour
{
    private int counter;
    void Start()
    {
        Destroy(this.gameObject, 6f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        counter++;
        if (collision.gameObject.tag == "GreenBall")
        {
            Destroy(this.gameObject);
        }
        if(counter == 2)
        {
            Destroy(this.gameObject);
        }
    }

}
