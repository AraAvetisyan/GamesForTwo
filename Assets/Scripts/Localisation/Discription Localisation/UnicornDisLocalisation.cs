using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UnicornDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Запомни единорога и собери такого же по памяти!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Memorize the unicorn and build one from memory!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Tek boynuzlu atı ezberleyin ve ezberden bir tane inşa edin!";
            play.text = "Oyun";

        }
    }
}
