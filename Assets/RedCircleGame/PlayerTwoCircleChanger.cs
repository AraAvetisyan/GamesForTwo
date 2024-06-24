using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoCircleChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] playerOneCircles;

    private void Start()
    {
    }
    public void ChangePlTwoCircle()
    {
        int choiser = Random.Range(0, playerOneCircles.Length);
        Debug.Log(choiser);
        for (int i = 0; i < playerOneCircles.Length; i++)
        {
            playerOneCircles[i].gameObject.SetActive(false);
        }
        playerOneCircles[choiser].SetActive(true);

    }
}
