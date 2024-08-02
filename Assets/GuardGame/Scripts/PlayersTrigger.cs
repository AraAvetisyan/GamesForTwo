using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTrigger : MonoBehaviour
{
    public bool GuardWin;
    private bool hits;
    [SerializeField] GuardTimer _guardTimer;
    [SerializeField] private AudioSource catchAudio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Robber")
        {
            catchAudio.Play();
            GuardWin = true;
            if(_guardTimer.Test == 1 && !hits)
            {
                _guardTimer.Test = 2;
                hits = true;
            }
            if(_guardTimer.Test == 2 && !hits)
            {
                _guardTimer.Test = 1;
                hits = true;
            }
            hits = false;
        }
    }
}
