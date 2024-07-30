using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingLightDisLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discription;
    [SerializeField] private TextMeshProUGUI play;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            discription.text = "Игроки должны удерживать свои кнопки, пока горит красный свет. Когда загорится зеленый свет, они должны отпустить кнопку. Игрок, который первым отпустит кнопку, получает очко. Игрок, набравший 3 очка, побеждает.";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Players must hold their buttons while the red light is on. When the light turns green, they must release the button. The player who releases the button first gets a point. The player who scores 3 points wins.";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Oyuncular kırmızı ışık yanarken düğmelerini tutmalıdır. Işık yeşile döndüğünde düğmeyi bırakmaları gerekir. Düğmeyi ilk bırakan oyuncu bir puan alır. 3 puan alan oyuncu kazanır.";
            play.text = "Oyun";

        }
    }
}
