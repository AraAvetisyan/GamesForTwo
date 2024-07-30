using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowlingLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerPlOne, winnerPlTwo;
    [SerializeField] private TextMeshProUGUI instruction;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOne.text = "ПОБЕДИТЕЛЬ";
            winnerPlTwo.text = "ПОБЕДИТЕЛЬ";
            instruction.text = "Свайп";
        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOne.text = "WINNER";
            winnerPlTwo.text = "WINNER";
            instruction.text = "Swipe";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOne.text = "Kazanan";
            winnerPlTwo.text = "Kazanan";
            instruction.text = "Kaydır.";
        }
    }
}
