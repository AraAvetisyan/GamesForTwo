using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathQuizDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Решай примеры правильно и быстро!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Solve examples correctly and quickly!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Örnekleri doğru ve hızlı bir şekilde çözün!";
            play.text = "Oyun";

        }
    }
}