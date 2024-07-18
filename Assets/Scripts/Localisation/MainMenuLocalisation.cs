using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player, players;
    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            player.text = "�����";
            players.text = "������";           
        }
        else if (Geekplay.Instance.language == "en")
        {
            player.text = "PLAYER";
            players.text = "PLAYERS";           
        }
        else if (Geekplay.Instance.language == "tr")
        {
            player.text = "oyuncu";
            players.text = "oyuncular";           
        }
    }
}
