using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTrigger : MonoBehaviour
{
    [SerializeField] private SummoGameScript _summoGameScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_summoGameScript.PlayerIndex == 1 && _summoGameScript.IsSingle)
        {
            if (collision.gameObject.tag == "PlayerTwo")
            {
                StartCoroutine(_summoGameScript.Single());
            }
        }
    }
}
