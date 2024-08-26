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
            discription.text = "Жми на зубы и пытайся не попасться крокодилу в пасть!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Click on the teeth and try not to get caught in the crocodile's mouth!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Dişlere tıklayın ve timsahın ağzına yakalanmamaya çalışın!";
            play.text = "Oyun";

        }
    }
}
