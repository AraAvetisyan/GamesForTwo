using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GreenBallDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Вам нужно выстрелить по зеленому мячу так, чтобы он оказался в зоне противника. Побеждает тот игрок, у которого больше очков по окончании таймера.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "You need to shoot the green ball so that it ends up in the opponent's zone. The player with the most points at the end of the timer wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Yeşil topu rakibin bölgesine girecek şekilde vurmanız gerekir. Zamanlayıcının sonunda en çok puana sahip olan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}
