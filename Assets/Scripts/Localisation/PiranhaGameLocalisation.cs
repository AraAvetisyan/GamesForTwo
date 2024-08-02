using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PiranhaGameLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerPlOne, winnerPlTwo;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOne.text = "онаедхрекэ";
            winnerPlTwo.text = "онаедхрекэ";

        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOne.text = "WINNER";
            winnerPlTwo.text = "WINNER";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOne.text = "Kazanan";
            winnerPlTwo.text = "Kazanan";

        }
    }
}
