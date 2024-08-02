using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalPanelLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerPlOne, winnerPlTwo;
    [SerializeField] private TextMeshProUGUI draw;
    [SerializeField] private TextMeshProUGUI toMenu, playeAgain;
    [SerializeField] private TextMeshProUGUI toMenu2, playeAgain2;
    [SerializeField] private TextMeshProUGUI toMenu3, playeAgain3;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOne.text = "Красный Игрок Победил";
            winnerPlTwo.text = "Синий Игрок Победил";
            toMenu.text = "В Меню";
            toMenu2.text = "В Меню";
            toMenu3.text = "В Меню";
            playeAgain.text = "Играть Еще";
            playeAgain2.text = "Играть Еще";
            playeAgain3.text = "Играть Еще";
            draw.text = "НИЧЬЯ";
        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOne.text = "RED PLAYER WINS";
            winnerPlTwo.text = "BLUE PLAYER WINS";
            toMenu.text = "TO MENU";
            playeAgain.text = "PLAY AGAIN";
            toMenu2.text = "TO MENU";
            playeAgain2.text = "PLAY AGAIN";
            toMenu3.text = "TO MENU";
            playeAgain3.text = "PLAY AGAIN";
            draw.text = "DRAW";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOne.text = "KIRMIZI OYUNCU KAZANIR";
            winnerPlTwo.text = "MAVI OYUNCU KAZANIR";
            toMenu.text = "MENÜYE";
            playeAgain.text = "TEKRAR OYNA";
            toMenu2.text = "MENÜYE";
            playeAgain2.text = "TEKRAR OYNA";
            toMenu3.text = "MENÜYE";
            playeAgain3.text = "TEKRAR OYNA";
            draw.text = "cizmek";
        }
    }
}
