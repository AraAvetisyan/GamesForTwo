using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnicornLocalisation : MonoBehaviour
{
    


    [SerializeField] private TextMeshProUGUI winnerPlOnePC, winnerPlOneMobile, winnerPlTwo;
    [SerializeField] private TextMeshProUGUI drawPlOnePC, drawPlOneMobile, drawPlTwo;
    [SerializeField] private TextMeshProUGUI rememberTheUnicorn;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOnePC.text = "ПОБЕДИТЕЛЬ";
            winnerPlOneMobile.text = "ПОБЕДИТЕЛЬ";
            winnerPlTwo.text = "ПОБЕДИТЕЛЬ";
            drawPlOnePC.text = "НИЧЬЯ";
            drawPlOneMobile.text = "НИЧЬЯ";
            drawPlTwo.text = "НИЧЬЯ";
            rememberTheUnicorn.text = "Запомните единорога ...";
        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOnePC.text = "WINNER";
            winnerPlOneMobile.text = "WINNER";
            winnerPlTwo.text = "WINNER";
            drawPlOnePC.text = "DRAW";
            drawPlOneMobile.text = "DRAW";
            drawPlTwo.text = "DRAW";
            rememberTheUnicorn.text = "REMEMBER THE UNICORN ...";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOnePC.text = "Kazanan";
            winnerPlOneMobile.text = "Kazanan";
            winnerPlTwo.text = "Kazanan";
            drawPlOnePC.text = "cizmek";
            drawPlOneMobile.text = "cizmek";
            drawPlTwo.text = "cizmek";
            rememberTheUnicorn.text = "Unicorn'u hatırla ...";
        }
    }
}
