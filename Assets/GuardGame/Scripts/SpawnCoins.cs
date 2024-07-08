using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject coinPrefab;
    void Start()
    {
        Spawn();
    }

   public void Spawn()
    {
        int rr = Random.Range(0, spawnPoints.Length);
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if (i == rr)
            {
                Instantiate(coinPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
