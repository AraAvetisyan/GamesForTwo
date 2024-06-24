using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TimerGost : MonoBehaviour
{
    private bool isHolding = false;
    [SerializeField] private GameObject buttonGost;
    [SerializeField] private Transform gostStartTransform;
    [SerializeField] private float speed;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        Debug.Log("RRR");
        buttonGost.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        buttonGost.SetActive(false);
        buttonGost.transform.position = gostStartTransform.position;
    }



    private void Update()
    {
        if (isHolding)
        {
            Debug.Log("Gyot");
            buttonGost.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ButtonGost")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}