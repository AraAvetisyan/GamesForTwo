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
            title.text = "ИГРЫ НА ДВОИХ";
            player.text = "Игрок";
            players.text = "Игрока";           
        }
        else if (Geekplay.Instance.language == "en")
        {

            title.text = "GAMES FOR TWO";
            player.text = "PLAYER";
            players.text = "PLAYERS";           
        }
        else if (Geekplay.Instance.language == "tr")
        {

            title.text = "İki Kişilik Oyunlar";
            player.text = "oyuncu";
            players.text = "oyuncular";           
        }
    }
}
