using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuardGameInstruction : MonoBehaviour
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
                redPlayerInstruction.text = "Джойстик";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Joystick";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Joystick";
            }
        }
        if (isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Джойстик";
                bluePlayerInstruction.text = "Джойстик";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Joystick";
                bluePlayerInstruction.text = "Joystick";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Joystick";
                bluePlayerInstruction.text = "Joystick";
            }
        }
        if (!isMobile && isSingle)
        {
            bluePlayerInstructionObject.SetActive(false);
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "W A S D";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "W A S D";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "W A S D";
            }
        }
        if (!isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "W A S D";
                bluePlayerInstruction.text = "Стрелки";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "W A S D";
                bluePlayerInstruction.text = "Arrows.";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "W A S D";
                bluePlayerInstruction.text = "Oklar";
            }
        }
    }
}
