using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootbalSingleTrigger : MonoBehaviour
{
    [SerializeField] private FootballPlayerOneRun playersRun;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playersRun.PlayerIndex == 1 && playersRun.IsSingle)
        {
            if (collision.gameObject.tag == "Ball")
            {
                StartCoroutine(playersRun.Single());
            }
        }
    }
}
