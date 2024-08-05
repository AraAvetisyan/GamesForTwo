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
    [SerializeField] private AudioSource hitCorral, hitPiranha;
    [SerializeField] private PiranhaGameManager _piranhaGameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piranha")
        {
            if (!_piranhaGameManager.EendGame)
            {
                hitPiranha.Play();
                Transform playerLineHit = collision.gameObject.transform;
                Vector2 direction = (playerLineHit.position - transform.position);
                rb.AddForce(-direction * force, ForceMode2D.Impulse);
                StartCoroutine(StopeForce());
                PlayerTwoPonts--;
                if (PlayerTwoPonts <= 0)
                {
                    PlayerTwoPonts = 0;
                }
                playerTwoPointsText.text = PlayerTwoPonts.ToString();
            }
        }
        if (collision.gameObject.tag == "Obsticle")
        {
            if (!_piranhaGameManager.EendGame)
            {
                hitCorral.Play();
                PlayerTwoPonts--;
                if (PlayerTwoPonts <= 0)
                {
                    PlayerTwoPonts = 0;
                }
                playerTwoPointsText.text = PlayerTwoPonts.ToString();

            }
        }
    }
    public IEnumerator StopeForce()
    {
        yield return new WaitForSeconds(.5f);
        rb.velocity = Vector2.zero;
    }
}
