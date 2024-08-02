using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScriptPlOne : MonoBehaviour
{
    [SerializeField] private DragItemsPlOne _dragItemsOne;
    [SerializeField] private bool isFall;
    [SerializeField] private Transform startPosition;
    int counter;
    public static Action<int> Pin;
    private bool hide;
    private bool isHiden;
    private Rigidbody2D rb;
    private bool gameEnds;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(_dragItemsOne.HidePin && !gameEnds)
        {
            StartCoroutine(HideAll());
        }
       
        if (_dragItemsOne.HitLine && !hide)
        {
            StartCoroutine(Hide());
        }
    }
    public IEnumerator Hide()
    {
        hide = true;
        isHiden = true;
        yield return new WaitForSeconds(4);
        if (transform.rotation.z != 0)
        {
            rb.velocity = Vector3.zero;
            Pin?.Invoke(1);
            this.gameObject.SetActive(false);
        }
        hide = false;
    }
    public IEnumerator HideAll()
    {
        yield return new WaitForSeconds(2);
        gameEnds = true;
    }
}
