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
    [SerializeField] private GameObject hitCorralObject, hitPiranhaObjrct;
    [SerializeField] private PiranhaGameManager _piranhaGameManager;
    private bool piranhaHit;
    private void Update()
    {
        if (PlayerOnePonts <= 0)
        {
            hitCorralObject.SetActive(false);
            hitPiranhaObjrct.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (!piranhaHit)
        {
            if (rb.velocity.magnitude > 0 || rb.angularVelocity > 0)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Piranha")
        {
            if (!_piranhaGameManager.EendGame)
            {
                piranhaHit = true;
                hitPiranha.Play();
                Transform playerLineHit = collision.gameObject.transform;
                Vector2 direction = (playerLineHit.position - transform.position).normalized;

                rb.AddForce(-direction * force, ForceMode2D.Impulse);

                StartCoroutine(StopeForce());
                PlayerOnePonts--;
                if (PlayerOnePonts <= 0)
                {
                    PlayerOnePonts = 0;
                }
                playerOnePointsText.text = PlayerOnePonts.ToString();
            }
        }
        if (collision.gameObject.tag == "Obsticle")
        {
            if (!_piranhaGameManager.EendGame)
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
        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            StartCoroutine(StopMovementCoroutine());
        }
    }
    private IEnumerator StopMovementCoroutine()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;

        yield return new WaitForFixedUpdate();

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
    }
    public IEnumerator StopeForce()
    {
        yield return new WaitForSeconds(.5f);
        rb.velocity = Vector2.zero;
        piranhaHit = false;
        rb.angularVelocity = 0;
    }
}
