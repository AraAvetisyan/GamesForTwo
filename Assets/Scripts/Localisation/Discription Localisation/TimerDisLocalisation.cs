using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Нажмите на кнопку, когда пройдет указанное время!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Press the button when the specified time has passed!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Belirtilen süre geçtiğinde düğmeye basın!";
            play.text = "Oyun";

        }
    }
}
