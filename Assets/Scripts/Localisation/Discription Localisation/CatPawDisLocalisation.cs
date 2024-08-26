using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatPawDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Подбирай желтых рыбок, не трогай черных!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Pick up the yellow fish, don't touch the black fish!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Sarı balığı alın, siyah balığa dokunmayın!";
            play.text = "Oyun";

        }
    }
}
