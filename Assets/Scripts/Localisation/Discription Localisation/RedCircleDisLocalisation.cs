using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedCircleDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Нажимайте, когда ваш кружок находится в отмеченной зоне!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Click when your circle is in the marked area!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Çemberiniz işaretli alana geldiğinde tıklayın!";
            play.text = "Oyun";

        }
    }
}
