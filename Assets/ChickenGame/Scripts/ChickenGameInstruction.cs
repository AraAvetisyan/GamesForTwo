using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChickenGameInstruction : MonoBehaviour
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
                redPlayerInstruction.text = "Красная кнопка";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Red button";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Kırmızı düğmeye";
            }
        }
        if (isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Красная кнопка";
                bluePlayerInstruction.text = "Синяя кнопка";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Red button";
                bluePlayerInstruction.text = "Blue button";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Kırmızı düğmeye";
                bluePlayerInstruction.text = "Mavi düğmeye";
            }
        }
        if (!isMobile && isSingle)
        {
            bluePlayerInstructionObject.SetActive(false);
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Z";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Z";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Z";
            }
        }
        if (!isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Z";
                bluePlayerInstruction.text = "M";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Z";
                bluePlayerInstruction.text = "M";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Z";
                bluePlayerInstruction.text = "M";
            }
        }
    }

}