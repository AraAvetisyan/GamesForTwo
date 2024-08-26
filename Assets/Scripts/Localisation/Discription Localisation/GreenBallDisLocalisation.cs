using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GreenBallDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Стреляй по зеленой шайбе и кати ее в зону противника!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Shoot the green puck and roll it into the opponent's zone!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Yeşil pakı vur ve rakip sahaya yuvarla!";
            play.text = "Oyun";

        }
    }
}
