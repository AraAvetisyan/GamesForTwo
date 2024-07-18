using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTrigger : MonoBehaviour
{
    [SerializeField] private SummoGameScriptPlOne _summoGameScriptPlOne;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_summoGameScriptPlOne.PlayerIndex == 1 && _summoGameScriptPlOne.IsSingle)
        {
            if (collision.gameObject.tag == "PlayerTwo")
            {
                StartCoroutine(_summoGameScriptPlOne.Single());
            }
        }
    }
}
