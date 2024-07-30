using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatPawDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Чтобы получить очки, нужно собирать желтых рыбок. Побеждает тот игрок, который наберет 5 очков.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "To get points, you need to collect yellow fish. The player who collects 5 points wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Puan kazanmak için sarı balıkları toplamanız gerekir. 5 puan toplayan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}
