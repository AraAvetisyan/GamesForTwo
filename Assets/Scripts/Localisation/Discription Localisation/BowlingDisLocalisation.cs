using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowlingDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;
    
    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Надо сбивать все кегли. Кто из игроков доходит до 60 очков тот побеждает.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "You have to knock down all the pins. Whichever player reaches 60 points wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Tüm lobutları devirmek zorundasınız. Hangi oyuncu 60 puana ulaşırsa o kazanır.";
            play.text = "Oyun";

        }
    }

   
}
