using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject eatableFishReference, notEatableFishReference, stanCounter;
    public bool FishIsActive;
    [SerializeField] private PlayerOneScript _playerOneScript;
    [SerializeField] private PlayerTwoScript _playerTwoScript;
    void Start()
    {
        StartCoroutine(WaitForSpawn());
    }

    public IEnumerator WaitForSpawn()
    {
        float sec = Random.Range(0.5f, 3f);
        int choiser = Random.Range(0, 4);
        yield return new WaitForSeconds(sec);
        if(choiser == 0 || choiser == 2 || choiser == 3)
        {
            eatableFishReference.SetActive(true);
            stanCounter.SetActive(false);
        }
        if (choiser == 1)
        {
            notEatableFishReference.SetActive(true);
            stanCounter.SetActive(false);
            FishIsActive = true;

            StartCoroutine(WaitToCloseFish());
        }
    }
    public IEnumerator WaitToCloseFish()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        if (FishIsActive)
        {
            
                stanCounter.SetActive(true);
                FishIsActive = false;
                notEatableFishReference.SetActive(false);

                StartCoroutine(WaitForSpawn());
            
        }
    }
}
