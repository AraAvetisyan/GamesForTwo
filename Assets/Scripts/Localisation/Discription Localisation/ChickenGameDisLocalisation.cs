using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChickenGameDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Изменяй гравитацию и доберись до финиша первым!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Change the gravity and get to the finish line first!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Yerçekimini değiştirin ve bitiş çizgisine ilk siz ulaşın!";
            play.text = "Oyun";

        }
    }
}
