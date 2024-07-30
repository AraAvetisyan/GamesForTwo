using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPawStartScript : MonoBehaviour
{
    [SerializeField] private GameObject spawner, startPanel;
 
    public void PressedStart()
    {
        spawner.SetActive(true);
        startPanel.SetActive(false);
    }
}
