using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoChooser : MonoBehaviour
{

    [SerializeField] private UnicornChooser _unicornChooser;
    public int counter;
    private int choos;
    [SerializeField] private GameObject[] plTwoHead, plTwoHair, plTwoCorn, plTwoFace, plTwoEyes;
    public int HeadInt, HairInt, CornInt, FaceInt, EyesInt;
    private bool headChosen, hairChosen, cornChosen, faceChosen, eyesChosen;
    public bool PlayerTwoEnds;
    public bool IsMobile;
    public bool IsSingle;
    [SerializeField] private GameObject buttonOne, buttonTwo;
    [SerializeField] private GameObject buttonBG;
    private void Awake()
    {
        if (Geekplay.Instance.mobile)
        {
            IsMobile = true;
        }
        else
        {
            IsMobile = false;
            buttonBG.SetActive(false);
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            if (!IsSingle)
            {
                buttonOne.SetActive(false);
                buttonTwo.SetActive(false);
            }
        }
    }   

    // Update is called once per frame
    void Update()
    {
        if (!IsMobile && Input.GetKeyDown(KeyCode.Z) && !IsSingle)
        {
            PressedButton();
        }
        if (!IsMobile && Input.GetKeyDown(KeyCode.Space) && IsSingle)
        {
            PressedButton();
        }
        if (_unicornChooser.Closed && counter == 0)
        {
            counter = 1;
        }
        if (counter == 1)
        {
            counter = 2;
            StartCoroutine(HeadChooser());
        }
        if (headChosen && counter == 2)
        {
            counter = 3;
        }
        if (counter == 3)
        {
            counter = 4;
            StartCoroutine(HairChooser());
        }
        if (hairChosen && counter == 4)
        {
            counter = 5;
        }
        if (counter == 5)
        {
            counter = 6;
            StartCoroutine(CornChooser());
        }
        if (cornChosen && counter == 6)
        {
            counter = 7;
        }
        if (counter == 7)
        {
            counter = 8;
            StartCoroutine(FaceChooser());
        }
        if (faceChosen && counter == 8)
        {
            counter = 9;
        }
        if (counter == 9)
        {
            StartCoroutine(EyesChooser());
            counter = 10;
        }
        if (eyesChosen && counter == 10)
        {
            PlayerTwoEnds = true;
            counter = 11;
        }

    }
    public void PressedButton()
    {
        if (choos == 1)
        {
            headChosen = true;
        }
        if (choos == 2)
        {
            hairChosen = true;
        }
        if (choos == 3)
        {
            cornChosen = true;
        }
        if (choos == 4)
        {
            faceChosen = true;
        }
        if (choos == 5)
        {
            eyesChosen = true;
        }
    }
    public IEnumerator HeadChooser()
    {
        choos = 1;
        if (HeadInt < plTwoHead.Length)
        {
            HeadInt++;
        }
        if (HeadInt >= plTwoHead.Length)
        {
            HeadInt = 0;
        }
        for (int i = 0; i < plTwoHead.Length; i++)
        {
            plTwoHead[i].SetActive(false);
        }
        plTwoHead[HeadInt].SetActive(true);
        yield return new WaitForSeconds(1f);

        if (!headChosen)
        {
            StartCoroutine(HeadChooser());
        }
    }
    public IEnumerator HairChooser()
    {
        choos = 2;
        if (HairInt < plTwoHair.Length)
        {
            HairInt++;
        }
        if (HairInt >= plTwoHair.Length)
        {
            HairInt = 0;
        }
        for (int i = 0; i < plTwoHair.Length; i++)
        {
            plTwoHair[i].SetActive(false);
        }
        plTwoHair[HairInt].SetActive(true);
        yield return new WaitForSeconds(1f);

        if (!hairChosen)
        {
            StartCoroutine(HairChooser());
        }
    }
    public IEnumerator CornChooser()
    {
        choos = 3;
        if (CornInt < plTwoCorn.Length)
        {
            CornInt++;
        }
        if (CornInt >= plTwoCorn.Length)
        {
            CornInt = 0;
        }
        for (int i = 0; i < plTwoCorn.Length; i++)
        {
            plTwoCorn[i].SetActive(false);
        }
        plTwoCorn[CornInt].SetActive(true);
        yield return new WaitForSeconds(1f);

        if (!cornChosen)
        {
            StartCoroutine(CornChooser());
        }
    }
    public IEnumerator FaceChooser()
    {
        choos = 4;
        if (FaceInt < plTwoFace.Length)
        {
            FaceInt++;
        }
        if (FaceInt >= plTwoFace.Length)
        {
            FaceInt = 0;
        }
        for (int i = 0; i < plTwoFace.Length; i++)
        {
            plTwoFace[i].SetActive(false);
        }
        plTwoFace[FaceInt].SetActive(true);
        yield return new WaitForSeconds(1f);

        if (!faceChosen)
        {
            StartCoroutine(FaceChooser());
        }
    }
    public IEnumerator EyesChooser()
    {
        choos = 5;
        if (EyesInt < plTwoEyes.Length)
        {
            EyesInt++;
        }
        if (EyesInt >= plTwoEyes.Length)
        {
            EyesInt = 0;
        }
        for (int i = 0; i < plTwoEyes.Length; i++)
        {
            plTwoEyes[i].SetActive(false);
        }
        plTwoEyes[EyesInt].SetActive(true);
        yield return new WaitForSeconds(1f);

        if (!eyesChosen)
        {
            StartCoroutine(EyesChooser());
        }
    }
}

