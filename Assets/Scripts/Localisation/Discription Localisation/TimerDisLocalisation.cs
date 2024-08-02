using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Игроки должны остановить таймер как можно ближе к заявленной в начале секунде. Побеждает тот игрок, который окажется ближе всех к цели.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Players must stop the timer as close as possible to the second declared at the beginning. The player who is closest to the goal wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Oyuncular zamanlayıcıyı başlangıçta belirtilen saniyeye mümkün oldugunca yakın durdurmalıdır. Hedefe en yakın olan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}
