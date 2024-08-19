using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingLightInstruction : MonoBehaviour
{
    private bool isMobile;
    [SerializeField] private bool isSingle;

    [SerializeField] private TextMeshProUGUI redPlayerInstruction, bluePlayerInstruction;
    [SerializeField] private GameObject bluePlayerInstructionObject;
    [SerializeField] private GameObject holdBlue, holdRed;

    [SerializeField] private Ease easeToBig;
    [SerializeField] private Ease easeToSmoll;
    [SerializeField] private Vector2 bigScale;
    [SerializeField] private Vector2 smollScale;
    [SerializeField] private TextMeshProUGUI holdRedText, holdBlueText, releaseText;
    public IEnumerator enumerator;
    void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;

        }
        Scaler();


        if (isMobile && isSingle)
        {
            bluePlayerInstructionObject.SetActive(false);
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Красная кнопка";
                holdRedText.text = "Удержать";
                releaseText.text = "Отпустить";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Red button";
                holdRedText.text = "Hold";
                releaseText.text = "Release";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Kırmızı düğmeye";
                holdRedText.text = "Tutun";
                releaseText.text = "Serbest bırakma";
            }
        }
        if (isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Красная кнопка";
                bluePlayerInstruction.text = "Синяя кнопка";
                holdBlueText.text = "Удержать";
                holdRedText.text = "Удержать";
                releaseText.text = "Отпустить";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Red button";
                bluePlayerInstruction.text = "Blue button";
                holdBlueText.text = "Hold";
                holdRedText.text = "Hold";
                releaseText.text = "Release";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Kırmızı düğmeye";
                bluePlayerInstruction.text = "Mavi düğmeye";
                holdBlueText.text = "Tutun";
                holdRedText.text = "Tutun";
                releaseText.text = "Serbest bırakma";
            }
        }
        if (!isMobile && isSingle)
        {
            bluePlayerInstructionObject.SetActive(false);
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Пробел";
                holdRedText.text = "Удержать";
                releaseText.text = "Отпустить";
            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Space";
                holdRedText.text = "Hold";
                releaseText.text = "Release";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Uzay";
                holdRedText.text = "Tutun";
                releaseText.text = "Serbest bırakma";
            }
        }
        if (!isMobile && !isSingle)
        {
            if (Geekplay.Instance.language == "ru")
            {
                redPlayerInstruction.text = "Z";
                bluePlayerInstruction.text = "M";
                holdBlueText.text = "Удержать";
                holdRedText.text = "Удержать";
                releaseText.text = "Отпустить";

            }
            else if (Geekplay.Instance.language == "en")
            {
                redPlayerInstruction.text = "Z";
                bluePlayerInstruction.text = "M";
                holdBlueText.text = "Hold";
                holdRedText.text = "Hold";
                releaseText.text = "Release";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                redPlayerInstruction.text = "Z";
                bluePlayerInstruction.text = "M";
                holdBlueText.text = "Tutun";
                holdRedText.text = "Tutun";
                releaseText.text = "Serbest bırakma";
            }
        }
    }
    public void Scaler()
    {
        enumerator = Pulsing();
        StartCoroutine(enumerator);
    }
    public void Killer()
    {
        DOTween.Kill(holdBlue);
        DOTween.Kill(holdRed);
        StopCoroutine(enumerator);
    }
    private IEnumerator Pulsing()
    {

        while (true)
        {

            holdRed.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 1f).SetEase(easeToSmoll);
            holdBlue.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 1f).SetEase(easeToSmoll);
            yield return new WaitForSeconds(1f);
            holdRed.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1f).SetEase(easeToBig);
            holdBlue.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1f).SetEase(easeToBig);
            yield return new WaitForSeconds(1f);


        }
       
    }
    //private void Update()
    //{
    //    if (getSmoller)
    //    {
    //        getSmoller = false;
    //        holdRed.transform.DOScale(smollScale, 0.3f).SetEase(easeToSmoll);
    //        holdBlue.transform.DOScale(smollScale, 0.3f).SetEase(easeToSmoll);
    //    }
    //    if (holdRed.transform.localScale.x == smollScale.x)
    //    {
    //        Debug.Log("get bigger true");
    //        getBigger = true;
    //    }
    //    if (getBigger)
    //    {
    //        getBigger = false;
    //        Debug.Log("get bigger false");
    //        holdRed.transform.DOScale(bigScale, 0.3f).SetEase(easeToBig);
    //        holdBlue.transform.DOScale(bigScale, 0.3f).SetEase(easeToBig);
    //    }
    //    if (holdRed.transform.localScale.x == bigScale.x)
    //    {
    //        Debug.Log("Big");
    //        getSmoller = true;
    //    }
    //}
}
