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
            discription.text = "Плыви от пираний и не цепляйся за риф!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Swim away from the piranhas and don't cling to the reef!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Piranalardan yüzerek uzaklaşın ve resiflere tutunmayın!";
            play.text = "Oyun";

        }
    }
}
