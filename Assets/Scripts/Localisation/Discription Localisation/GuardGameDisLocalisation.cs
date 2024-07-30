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
            discription.text = "Вам нужно избегать охранника и собирать монеты. если охранник поймает вора, игроки меняются ролями. побеждает тот, кто первым соберет 5 монет.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "You need to avoid the guard and collect coins. if the guard catches the thief, the players switch roles. the one who collects 5 coins first wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Bekçiden kaçmanız ve paraları toplamanız gerekir. eğer bekçi hırsızı yakalarsa, oyuncular rolleri değiştirir. 5 parayı ilk toplayan kazanır.";
            play.text = "Oyun";

        }
    }
}
