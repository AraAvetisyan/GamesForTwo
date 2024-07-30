using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DinoInstruction : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI playerInstruction;
    void Start()
    {



        if (Geekplay.Instance.language == "ru")
        {
            playerInstruction.text = "Нажмите на один из зубов.";
        }
        else if (Geekplay.Instance.language == "en")
        {
            playerInstruction.text = "Press the red button to play.";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            playerInstruction.text = "Dişlerden birine tıklayın.";
        }


    }
}
