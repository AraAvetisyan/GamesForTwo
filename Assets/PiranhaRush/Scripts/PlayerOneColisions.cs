using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerOneColisions : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    public int PlayerOnePonts;
    [SerializeField] private TextMeshProUGUI playerOnePointsText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Piranha")
        {
            Transform playerLineHit = collision.gameObject.transform;
            Vector2 direction = (playerLineHit.position - transform.position);
            rb.AddForce(-direction * force, ForceMode2D.Force);
            PlayerOnePonts--;
            playerOnePointsText.text = PlayerOnePonts.ToString();
        }
        if (collision.gameObject.tag == "Obsticle")
        {
            PlayerOnePonts--;
            playerOnePointsText.text = PlayerOnePonts.ToString();
        }
    }
}
