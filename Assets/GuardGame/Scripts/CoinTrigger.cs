using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public int CoinCount;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private SpawnCoins _spawnCoins;
    [SerializeReference] private AudioSource coinSound;
    void Start() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin" && this.gameObject.tag != "Guard")
        {
            coinSound.Play();
            CoinCount++;
            coinsText.text = CoinCount.ToString();
            Destroy(collision.gameObject);
            _spawnCoins.Spawn();
        }
    }
}
