using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuardGameDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Коп должен ловить вора, а вор собирать монеты!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "The cop has to catch the thief and the thief has to collect the coins!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Polis hırsızı yakalamalı ve hırsız da paraları toplamalıdır!";
            play.text = "Oyun";

        }
    }
}
