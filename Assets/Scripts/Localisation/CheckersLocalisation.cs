using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CheckersLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI whitesTurn;
    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            whitesTurn.text = "очередь белых";
        }
        else if (Geekplay.Instance.language == "en")
        {
            whitesTurn.text = "White`s turn";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            whitesTurn.text = "beyaz sirasi";
        }
    }

    
}
