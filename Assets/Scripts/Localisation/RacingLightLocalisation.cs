using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingLightLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerPlOnePC, winnerPlOneMobile, winnerPlTwo;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOnePC.text = "онаедхрекэ";
            winnerPlOneMobile.text = "онаедхрекэ";
            winnerPlTwo.text = "онаедхрекэ";

        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOnePC.text = "WINNER";
            winnerPlOneMobile.text = "WINNER";
            winnerPlTwo.text = "WINNER";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOnePC.text = "Kazanan";
            winnerPlOneMobile.text = "Kazanan";
            winnerPlTwo.text = "Kazanan";

        }
    }
}
