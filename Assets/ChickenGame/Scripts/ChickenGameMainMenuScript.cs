using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChickenGameMainMenuScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    [SerializeField] private GameObject disPanel1, disPanel2, disPanel3;
    [SerializeField] private GameObject disPanel1Mobile, disPanel2Mobile, disPanel3Mobile;
    public int Index;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private bool isMobile;

    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
        }
    }


    public void PressedChickenGameOne()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            disPanel1.SetActive(true);
        }
        if (isMobile)
        {
            disPanel1Mobile.SetActive(true);
        }
        Index = 1;
    }
    public void PressedChickenGameTwo()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            disPanel2.SetActive(true);
        }
        if (isMobile)
        {
            disPanel2Mobile.SetActive(true);
        }
        Index = 2;
    }
    public void PressedChickenGameThree()
    {
        buttonSound.Play();
        if (!isMobile)
        {
            disPanel3.SetActive(true);
        }
        if (isMobile)
        {
            disPanel3Mobile.SetActive(true);
        }
        Index = 3;
    }
    public void PressedHome()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
