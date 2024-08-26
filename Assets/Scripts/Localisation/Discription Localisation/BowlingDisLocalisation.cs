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
            discription.text = "Сбивай кегли и первым набери 60 очков!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Knock down the skittles and be the first to score 60 points!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Kukaları devir ve 60 puana ulaşan ilk kişi ol!";
            play.text = "Oyun";

        }
    }

   
}
