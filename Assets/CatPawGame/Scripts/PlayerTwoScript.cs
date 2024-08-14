using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTwoScript : MonoBehaviour
{
    public int Points;
    private int stanCounter;
    [SerializeField] private Button playerTwoButton;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private FishSpawner _fishSpawner;
    [SerializeField] private CatPawGameUIController _catPawGameUIController;
    [SerializeField] private GameObject stan;
    [SerializeField] private Transform playerTwoPosition;
    [SerializeField] private bool goBack;
    [SerializeField] AudioSource eatableSound, notEatableSound;
    // [SerializeField] private float speed;
    public bool CantPlay;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EatableFish")
        {
            if (collision.gameObject.activeSelf)
            {
                collision.gameObject.SetActive(false);
                eatableSound.Play();
                _catPawGameUIController.ButtonTwoPressed = false;
                //   transform.position = new Vector2(6f, 6f);
                goBack = true;
                Points += 1;
                pointsText.text = Points.ToString();
                stanCounter = 0;
                if (Points != 5)
                {
                    StartCoroutine(_fishSpawner.WaitForSpawn());
                }
                stan.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "NoteatableFish")
        {
            collision.gameObject.SetActive(false);
            notEatableSound.Play();
            _catPawGameUIController.ButtonTwoPressed = false;
            //  transform.position = new Vector2(6f, 6f);
            goBack = true;
            Points -= 2;
            pointsText.text = Points.ToString();
            stanCounter = 0;
            _fishSpawner.FishIsActive = false;
            StartCoroutine(_fishSpawner.WaitForSpawn());
            stan.SetActive(true);
        }
        if (collision.gameObject.tag == "Counter")
        {
            _catPawGameUIController.ButtonTwoPressed = false;
            // transform.position = new Vector2(6f, 6f);
            goBack = true;
            //stanCounter++;
        }
        if (goBack)
        {
            if (collision.gameObject.tag == "GoBack")
            {
                CantPlay = false;
                goBack = false;
            }
        }
        if (collision.gameObject.CompareTag("GoBackCatTwo"))
        {
            CantPlay = true;
            _catPawGameUIController.ButtonTwoPressed = false;
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
        playerTwoButton.interactable = false;
        CantPlay = true;
        yield return new WaitForSeconds(2);
        playerTwoButton.interactable = true;
        CantPlay = false;
    }
}












































//public int Points;
//private int stanCounter;
//[SerializeField] private Button playerOneButton;
//[SerializeField] private TextMeshProUGUI pointsText;
//[SerializeField] private FishSpawner _fishSpawner;
//[SerializeField] private CatPawGameUIController _catPawGameUIController;
//[SerializeField] private GameObject stan;
//[SerializeField] private Transform playerTwoPosition;
//private bool goBack;
//[SerializeField] private float speed;
//public bool CantPlay;

//private void OnTriggerEnter2D(Collider2D collision)
//{
//    if (collision.gameObject.tag == "EatableFish")
//    {
//        _catPawGameUIController.ButtonOnePressed = false;
//        //   transform.position = new Vector2(6f, 6f);
//        goBack = true;
//        collision.gameObject.SetActive(false);
//        Points += 1;
//        pointsText.text = Points.ToString();
//        stanCounter = 0; if (Points != 3)
//        {
//            StartCoroutine(_fishSpawner.WaitForSpawn());
//        }
//        stan.SetActive(true);
//    }
//    if (collision.gameObject.tag == "NoteatableFish")
//    {
//        _catPawGameUIController.ButtonOnePressed = false;
//        //  transform.position = new Vector2(6f, 6f);
//        goBack = true;
//        collision.gameObject.SetActive(false);
//        Points -= 2;
//        pointsText.text = Points.ToString();
//        stanCounter = 0;
//        _fishSpawner.FishIsActive = false;

//        StartCoroutine(_fishSpawner.WaitForSpawn());

//        stan.SetActive(true);
//    }
//    if (collision.gameObject.tag == "Counter")
//    {
//        _catPawGameUIController.ButtonOnePressed = false;
//        // transform.position = new Vector2(6f, 6f);
//        goBack = true;
//        stanCounter++;
//    }
//    if (goBack)
//    {
//        if (collision.gameObject.tag == "GoBack")
//        {
//            goBack = false;
//        }
//    }
//    if (collision.gameObject.CompareTag("Path"))
//    {
//        _catPawGameUIController.ButtonTwoPressed = false;
//        Debug.Log("Erkrordy zanec ");
//    }
//}
//private void Update()
//{
//    if (stanCounter == 3)
//    {
//        StartCoroutine(WaitForStan());
//    }
//    if (goBack)
//    {
//        transform.Translate(Vector3.up * speed * Time.deltaTime);
//    }
//}
//private IEnumerator WaitForStan()
//{
//    stanCounter = 0;
//    playerOneButton.interactable = false;
//    CantPlay = true;
//    yield return new WaitForSeconds(2);
//    playerOneButton.interactable = true;
//    CantPlay = false;
//}