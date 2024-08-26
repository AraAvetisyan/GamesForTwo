using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FootballBallDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Это футбол! Бей мяч в ворота противника!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "It's soccer! Kick the ball into the opposing goal!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Bu futbol! Topu rakibin kalesine at!";
            play.text = "Oyun";

        }
    }
}
