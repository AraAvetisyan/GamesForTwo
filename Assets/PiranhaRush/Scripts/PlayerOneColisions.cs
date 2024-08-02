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
    [SerializeField] private AudioSource hitCorral, hitPiranha;
    private void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Piranha")
        {
            hitPiranha.Play();
            Transform playerLineHit = collision.gameObject.transform;
            Vector2 direction = (playerLineHit.position - transform.position);
            rb.AddForce(-direction * force, ForceMode2D.Impulse);
            StartCoroutine(StopeForce());
            PlayerOnePonts--;
            if (PlayerOnePonts <= 0)
            {
                PlayerOnePonts = 0;
            }
            playerOnePointsText.text = PlayerOnePonts.ToString();
        }
        if (collision.gameObject.tag == "Obsticle")
        {
            hitCorral.Play();
            PlayerOnePonts--;
            if (PlayerOnePonts <= 0)
            {
                PlayerOnePonts = 0;
            }
            playerOnePointsText.text = PlayerOnePonts.ToString();
        }
    }
    public IEnumerator StopeForce()
    {
        yield return new WaitForSeconds(.5f);
      
        rb.velocity = Vector2.zero;
    }
}
