using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player, players, title;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            title.text = "Игры на двоих: Сборник";
            player.text = "Игрок";
            players.text = "Игрока";           
        }
        else if (Geekplay.Instance.language == "en")
        {

            title.text = "Games for Two: Collection";
            player.text = "Player";
            players.text = "Players";           
        }
        else if (Geekplay.Instance.language == "tr")
        {

            title.text = "İki Kişilik Oyunlar: Koleksiyon";
            player.text = "oyuncu";
            players.text = "oyuncular";           
        }
    }
}
