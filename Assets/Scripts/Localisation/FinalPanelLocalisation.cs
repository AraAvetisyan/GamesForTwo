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
            winnerPlOne.text = "Красный игрок победил";
            winnerPlTwo.text = "Синий игрок победил";
            toMenu.text = "В меню";
            toMenu2.text = "В меню";
            toMenu3.text = "В меню";
            playeAgain.text = "Играть еще";
            playeAgain2.text = "Играть еще";
            playeAgain3.text = "Играть еще";
            draw.text = "НИЧЬЯ";
        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOne.text = "Red player wins";
            winnerPlTwo.text = "Blue player wins";
            toMenu.text = "To menu";
            playeAgain.text = "Play again";
            toMenu2.text = "To menu";
            playeAgain2.text = "Play again";
            toMenu3.text = "To menu";
            playeAgain3.text = "Play again";
            draw.text = "Draw";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOne.text = "Kirmizi oyuncu kazanir";
            winnerPlTwo.text = "Mavi oyuncu kazanir";
            toMenu.text = "Menuye";
            playeAgain.text = "Tekrar oyna";
            toMenu2.text = "Menuye";
            playeAgain2.text = "Tekrar oyna";
            toMenu3.text = "Menuye";
            playeAgain3.text = "Tekrar oyna";
            draw.text = "Cizmek";
        }
    }
}
