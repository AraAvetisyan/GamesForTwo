using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CheckersDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Это классические шашки. Чтобы победить, нужно съесть все шашки соперника.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "It's classic checkers. To win, you have to eat all of your opponent's checkers.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Klasik dama. Kazanmak için rakibinizin tüm pullarını yemelisiniz.";
            play.text = "Oyun";

        }
    }
}
