using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoCircleChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] playerOneCircles;
    [SerializeField] private RedCirclePlayerTwoScript _redCirclePlayerTwoScript;
    public int LastCircle;
  
    public void ChangePlTwoCircle()
    {
        int choiser = Random.Range(0, playerOneCircles.Length);
        if (choiser == LastCircle)
        {
            choiser = Random.Range(0, playerOneCircles.Length);
        }
        for (int i = 0; i < playerOneCircles.Length; i++)
        {
            playerOneCircles[i].gameObject.SetActive(false);
        }
        playerOneCircles[choiser].SetActive(true);
        LastCircle = choiser;
    
    }
    public void ChangeToLastCircle()
    {
        playerOneCircles[LastCircle].SetActive(true);
    }
}
