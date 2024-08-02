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
            discription.text = "Вам предстоит забивать голы в ворота соперника. Тот, кто наберет пять очков, победит.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "You will have to score goals in the opponent's goal. Whoever scores five points wins the game.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Rakibin kalesine gol atmanız gerekecek. Kim beş sayı yaparsa oyunu kazanır.";
            play.text = "Oyun";

        }
    }
}
