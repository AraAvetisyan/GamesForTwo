using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTwoColisions : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    public int PlayerTwoPonts;
    [SerializeField] private TextMeshProUGUI playerTwoPointsText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piranha")
        {
            Transform playerLineHit = collision.gameObject.transform;
            Vector2 direction = (playerLineHit.position - transform.position);
            rb.AddForce(-direction * force, ForceMode2D.Impulse);
            StartCoroutine(StopeForce());
            PlayerTwoPonts--;
            playerTwoPointsText.text = PlayerTwoPonts.ToString();
        }
        if (collision.gameObject.tag == "Obsticle")
        {
            PlayerTwoPonts--;
            playerTwoPointsText.text = PlayerTwoPonts.ToString();
        }
    }
    public IEnumerator StopeForce()
    {
        yield return new WaitForSeconds(.5f);
        rb.velocity = Vector2.zero;
    }
}