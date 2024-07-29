using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneScript : MonoBehaviour
{
    public int Points;
    private int stanCounter;
    [SerializeField] private Button playerOneButton;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private FishSpawner _fishSpawner;
    [SerializeField] private CatPawGameUIController _catPawGameUIController;
    [SerializeField] private GameObject stan;
    [SerializeField] private Transform playerOnePosition;
    private bool goBack;
   // [SerializeField] private float speed;
    public bool CantPlay;
    private void Start()
    {
        if(_catPawGameUIController.IsMobile && !_catPawGameUIController.IsSingle)
        {
            pointsText.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        if(!_catPawGameUIController.IsMobile || _catPawGameUIController.IsSingle)
        {
            pointsText.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "EatableFish")
        {
            _catPawGameUIController.ButtonOnePressed = false;
         //   transform.position = new Vector2(6f, 6f);
            goBack = true;
            collision.gameObject.SetActive(false);
            Points += 1;
            pointsText.text = Points.ToString();
            stanCounter = 0;
            if (Points != 5)
            {
                StartCoroutine(_fishSpawner.WaitForSpawn());
            }
            stan.SetActive(true);
        }
        if(collision.gameObject.tag == "NoteatableFish")
        {
            _catPawGameUIController.ButtonOnePressed = false;
          //  transform.position = new Vector2(6f, 6f);
            goBack=true;
            collision.gameObject.SetActive(false);
            Points -= 2;
            pointsText.text = Points.ToString();
            stanCounter = 0;
            _fishSpawner.FishIsActive = false;
            StartCoroutine(_fishSpawner.WaitForSpawn());
            stan.SetActive(true);
        }
        if (collision.gameObject.tag == "Counter")
        {
            _catPawGameUIController.ButtonOnePressed = false;
            // transform.position = new Vector2(6f, 6f);
            goBack = true;
           // stanCounter++;
        }
        if (goBack)
        {
            if(collision.gameObject.tag == "GoBack")
            {
                goBack = false;
            }
        }
        if (collision.gameObject.CompareTag("Path"))
        {
            _catPawGameUIController.ButtonOnePressed = false;
        }
    }
    private void Update()
    {
        if (stanCounter == 3)
        {
            StartCoroutine(WaitForStan());            
        }
        //if (goBack)
        //{
        //    transform.Translate(Vector3.up * speed * Time.deltaTime);
        //}
    }
    private IEnumerator WaitForStan()
    {
        stanCounter = 0;
        playerOneButton.interactable = false;
        CantPlay = true;
        yield return new WaitForSeconds(2);
        playerOneButton.interactable = true;
        CantPlay = false;
    }
}

//Vector2 direction = Vector2.up * FloatingJoystick.Vertical + Vector2.right * FloatingJoystick.Horizontal;
//transform.Translate(direction * speed * Time.deltaTime);