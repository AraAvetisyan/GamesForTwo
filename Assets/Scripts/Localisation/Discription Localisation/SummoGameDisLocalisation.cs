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
            discription.text = "Вам нужно вытолкнуть противника за край арены. Побеждает игрок, набравший 3 очка.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "You need to push your opponent over the edge of the arena. The player with 3 points wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Rakibinizi arenanın kenarından itmeniz gerekir. 3 puana sahip olan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}

