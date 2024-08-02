using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathQuizDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Вы должны ответить правильно быстрее, чем ваш соперник. Побеждает игрок, который быстрее наберёт 5 очков.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "You must answer correctly faster than your opponent. The player who gets 5 points faster wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Rakibinizden daha hızlı dogru cevap vermelisiniz. 5 puan daha hızlı alan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}