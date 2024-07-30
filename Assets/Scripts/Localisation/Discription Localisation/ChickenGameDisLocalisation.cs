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
            discription.text = "Доберитесь до финиша, изменяя силу тяжести. Побеждает тот игрок, который первым доберется до финиша.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Get to the finish line by changing the gravity. The player who reaches the finish line first wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Yerçekimini değiştirerek bitiş çizgisine ulaşın. Bitiş çizgisine ilk ulaşan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}
