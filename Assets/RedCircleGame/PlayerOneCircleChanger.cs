using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneCircleChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] playerOneCircles;

    public void ChangePlOneCircle()
    {
        int choiser = Random.Range(0, playerOneCircles.Length);
        Debug.Log(choiser);
        for(int i = 0; i < playerOneCircles.Length; i++)
        {
            playerOneCircles[i].gameObject.SetActive(false);
        }
        playerOneCircles[choiser].SetActive(true);

    }
}
