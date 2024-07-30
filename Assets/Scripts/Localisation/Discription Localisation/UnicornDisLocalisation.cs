using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UnicornDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Игроки должны запомнить начального единорога и собрать его до истечения таймера. За каждый правильный ответ дается пять очков. Побеждает игрок, набравший наибольшее количество очков.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Players must memorize the initial unicorn and collect it before the timer expires. Five points are given for each correct answer. The player with the most points wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Oyuncular ilk tek boynuzlu atı ezberlemeli ve zamanlayıcı sona ermeden önce toplamalıdır. Her doğru cevap için beş puan verilir. En çok puana sahip olan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}
