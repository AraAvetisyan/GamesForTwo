using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PiranhaGameDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Каждый игрок имеет 20 очков. каждый раз, когда игрок касается пираньи или коралла, у него отнимается 1 очко. игрок с 0 очками проигрывает.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Each player has 20 points. each time a player touches a piranha or coral, 1 point is taken away. a player with 0 points loses.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Her oyuncunun 20 puanı vardır. bir oyuncu bir pirana veya mercana her dokundugunda, 1 puan alınır. 0 puanı olan bir oyuncu kaybeder.";
            play.text = "Oyun";

        }
    }
}
