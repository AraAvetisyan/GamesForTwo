using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowlingLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerPlOne, winnerPlTwo;
    [SerializeField] private TextMeshProUGUI instructionRed, instructionBlue;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOne.text = "ПОБЕДИТЕЛЬ";
            winnerPlTwo.text = "ПОБЕДИТЕЛЬ";
            instructionRed.text = "Свайп";
            instructionBlue.text = "Свайп";
        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOne.text = "WINNER";
            winnerPlTwo.text = "WINNER";
            instructionRed.text = "Swipe";
            instructionBlue.text = "Swipe";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOne.text = "Kazanan";
            winnerPlTwo.text = "Kazanan";
            instructionRed.text = "Kaydır";
            instructionBlue.text = "Kaydır";
        }
    }
}
