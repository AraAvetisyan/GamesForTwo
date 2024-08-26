using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class SummoGameDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Вытолкните противника за край арены!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Push your opponent over the edge of the arena!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Rakibinizi arenanın kenarından itin!";
            play.text = "Oyun";

        }
    }
}

