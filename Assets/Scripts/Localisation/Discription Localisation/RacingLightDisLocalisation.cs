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
            discription.text = "Удерживай кнопку и отпусти ее, когда загорится зеленый!";
            play.text = "Играть";
        }
        else if (Geekplay.Instance.language == "en")
        {
            discription.text = "Hold down the button and release it when it turns green!";
            play.text = "Play";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            discription.text = "Düğmeyi basılı tutun ve yeşile döndüğünde bırakın!";
            play.text = "Oyun";

        }
    }
}
