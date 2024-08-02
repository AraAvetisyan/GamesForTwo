using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GreenBallLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerPlOnePC, winnerPlOneMobile, winnerPlTwo;
    [SerializeField] private TextMeshProUGUI drawPlOnePC, drawPlOneMobile, drawPlTwo;
    [SerializeField] private TextMeshProUGUI goalPlOne, goalPlTwo;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOnePC.text = "����������";
            winnerPlOneMobile.text = "����������";
            winnerPlTwo.text = "����������";
            drawPlOnePC.text = "�����";
            drawPlOneMobile.text = "�����";
            drawPlTwo.text = "�����";
            goalPlOne.text = "���";
            goalPlTwo.text = "���";

        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOnePC.text = "WINNER";
            winnerPlOneMobile.text = "WINNER";
            winnerPlTwo.text = "WINNER";
            drawPlOnePC.text = "DRAW";
            drawPlOneMobile.text = "DRAW";
            drawPlTwo.text = "DRAW";
            goalPlOne.text = "GOAL";
            goalPlTwo.text = "GOAL";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOnePC.text = "Kazanan";
            winnerPlOneMobile.text = "Kazanan";
            winnerPlTwo.text = "Kazanan";
            drawPlOnePC.text = "cizmek";
            drawPlOneMobile.text = "cizmek";
            drawPlTwo.text = "cizmek";
            goalPlOne.text = "GOL";
            goalPlTwo.text = "GOL";

        }
    }
}
