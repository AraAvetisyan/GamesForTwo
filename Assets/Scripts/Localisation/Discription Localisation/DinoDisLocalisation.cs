using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DinoDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Игроки по очереди нажимают на зубы. Один из зубов не является счастливым. Тот игрок, который нажмет на этот зуб, проигрывает.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Players take turns clicking on the teeth. One of the teeth is not a lucky tooth. The player who presses that tooth loses.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Oyuncular sırayla dişlerin üzerine tıklar. Dişlerden biri şanslı diş değildir. O dişe basan oyuncu kaybeder.";
            play.text = "Oyun";

        }
    }
}
