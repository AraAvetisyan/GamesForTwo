using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroer : MonoBehaviour
{
    private int counter;
   // public GreenBallGameUIController _GameUIController;
    public AudioSource collisionAudio;
    void Start()
    {
        Destroy(this.gameObject, 6f);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        counter++;
        if (collision.gameObject.tag == "GreenBall")
        {
            GreenBallGameUIController.Instance.CollisionAudio.Play();
            Destroy(this.gameObject);
        }
        if(counter == 2)
        {
            Destroy(this.gameObject);
        }
    }

}
