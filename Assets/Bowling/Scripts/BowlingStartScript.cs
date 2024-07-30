using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingStartScript : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    
    public void PressedPlay()
    {
        startPanel.SetActive(false);
    }
}
