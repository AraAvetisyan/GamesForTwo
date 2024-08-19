using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MathQuizInstruction : MonoBehaviour
{
    private bool isMobile;
    [SerializeField] private bool isSingle;

    [SerializeField] private TextMeshProUGUI redPlayerInstruction, bluePlayerInstruction;
    [SerializeField] private GameObject bluePlayerInstructionObject;
    void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;

        }


        if (isMobile && isSingle)
        {
            bluePlayerInstructionObject.SetActive(false);
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Красные кнопки.";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Red buttons";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Kırmızı düğmeler";
            }
        }
        if (isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Красные кнопки";
                bluePlayerInstruction.text = "Синие кнопки";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Red buttons";
                bluePlayerInstruction.text = "Blue buttons";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Kırmızı düğmeler";
                bluePlayerInstruction.text = "Mavi düğmeler";
            }
        }
        if (!isMobile && isSingle)
        {
            bluePlayerInstructionObject.SetActive(false);
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "A S D";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "A S D";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "A S D";
            }
        }
        if (!isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Z X C";
                bluePlayerInstruction.text = "Стрелки";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Z X C";
                bluePlayerInstruction.text = "Arrows.";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Z X C";
                bluePlayerInstruction.text = "Oklar";
            }
        }
    }
}
