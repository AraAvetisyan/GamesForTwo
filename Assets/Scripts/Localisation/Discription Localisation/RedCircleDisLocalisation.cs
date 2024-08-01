using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedCircleDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Игрок должен нажать на кнопку, когда мяч окажется в выделенной области. Побеждает игрок, набравший наибольшее количество очков по истечении таймера.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "The player must press the button when the ball is in the highlighted area. The player with the most points after the timer expires wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Oyuncu, top vurgulanan alana geldiginde dügmeye basmalıdır. Zamanlayıcı sona erdikten sonra en çok puana sahip olan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}
