using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScriptPlTwo : MonoBehaviour
{
    [SerializeField] private DragItemsPlTwo _dragItemsTwo;
    [SerializeField] private bool isFall;
    int counter;
    public static Action<int> Pin;
    private bool hide;
    private Rigidbody2D rb;
    private bool gameEnds;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dragItemsTwo.HidePin && !gameEnds)
        {
            StartCoroutine(HideAll());
        }

        if (_dragItemsTwo.HitLine && !hide)
        {
            StartCoroutine(Hide());
        }
    }
    public IEnumerator Hide()
    {
        hide = true;
        yield return new WaitForSeconds(6);
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
