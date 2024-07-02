using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;
    [SerializeField] private GameObject buttonGost;
    [SerializeField] private Transform gostStartTransform;
    [SerializeField] private float speed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
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
            buttonGost.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

}
