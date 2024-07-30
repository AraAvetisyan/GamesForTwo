using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballBallStartScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bc2D;
    [SerializeField] private GameObject startPanel;

    public void PressedPlay()
    {
        bc2D.enabled = true;
        startPanel.SetActive(false);
    }
}
