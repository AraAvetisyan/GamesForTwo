using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneChooser : MonoBehaviour
{
    [SerializeField] private UnicornChooser _unicornChooser;
    public int counter;
    private int choos;
    [SerializeField] private GameObject[] plOneHead, plOneHair, plOneCorn, plOneFace, plOneEyes;
    public int HeadInt, HairInt, CornInt, FaceInt, EyesInt;
    private bool headChosen, hairChosen, cornChosen, faceChosen, eyesChosen;
    public bool PlayerOneEnds;
    private bool isMobile;

    [SerializeField] bool isSingle;
    [SerializeField] private GameObject buttonOne, buttonTwo;
    void Start()
    {

        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
            if (!isSingle)
            {
                buttonOne.SetActive(false);
                buttonTwo.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMobile && Input.GetKeyDown(KeyCode.M) && !isSingle)
        {
            PressedButton();
        }
        if (_unicornChooser.Closed && counter == 0)
        {
            counter = 1;
        }
        if(counter == 1)
        {
            counter = 2;
            StartCoroutine(HeadChooser());
            if (isSingle)
            {
                StartCoroutine(Single());
            }
        }
        if (headChosen && counter == 2)
        {
            counter = 3;
        }
        if(counter == 3)
        {
            counter = 4;
            StartCoroutine(HairChooser());
            if (isSingle)
            {
                StartCoroutine(Single());
            }
        }
        if (hairChosen && counter == 4)
        {
            counter = 5;
        }
        if(counter == 5)
        {
            counter = 6;
            StartCoroutine(CornChooser());
            if (isSingle)
            {
                StartCoroutine(Single());
            }
        }
        if (cornChosen && counter == 6)
        {
            counter = 7;
        }
        if(counter == 7)
        {
            counter = 8;
            StartCoroutine(FaceChooser());
            if (isSingle)
            {
                StartCoroutine(Single());
            }
        }
        if (faceChosen && counter == 8)
        {
            counter = 9;
        }
        if(counter == 9)
        {
            StartCoroutine(EyesChooser());
            if (isSingle)
            {
                StartCoroutine(Single());
            }
            counter = 10;
        }
        if(eyesChosen && counter == 10)
        {
            PlayerOneEnds = true;
            counter = 11;
        }
        
    }
    public IEnumerator Single()
    {
        float timer = Random.Range(0.5f, 3f);
        yield return new WaitForSeconds(timer);
        PressedButton();
    }
    public void PressedButton()
    {
        if(choos == 1)
        {
            headChosen = true;
        }
        if (choos == 2)
        {
            hairChosen = true;
        }
        if(choos == 3)
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
        if (HeadInt < plOneHead.Length)
        {
            HeadInt++;
        }
        if(HeadInt >= plOneHead.Length)
        {
            HeadInt = 0;
        }
        for(int i =0; i< plOneHead.Length; i++)
        {
            plOneHead[i].SetActive(false);
        }
        plOneHead[HeadInt].SetActive(true);
        yield return new WaitForSeconds(0.5f);

        if (!headChosen)
        {
            StartCoroutine(HeadChooser());
        }
    }
    public IEnumerator HairChooser()
    {
        choos = 2;
        if (HairInt < plOneHair.Length)
        {
            HairInt++;
        }
        if (HairInt >= plOneHair.Length)
        {
            HairInt = 0;
        }
        for (int i = 0; i < plOneHair.Length; i++)
        {
            plOneHair[i].SetActive(false);
        }
        plOneHair[HairInt].SetActive(true);
        yield return new WaitForSeconds(0.5f);

        if (!hairChosen)
        {
            StartCoroutine(HairChooser());
        }
    }
    public IEnumerator CornChooser()
    {
        choos = 3;
        if (CornInt < plOneCorn.Length)
        {
            CornInt++;
        }
        if (CornInt >= plOneCorn.Length)
        {
            CornInt = 0;
        }
        for (int i = 0; i < plOneCorn.Length; i++)
        {
            plOneCorn[i].SetActive(false);
        }
        plOneCorn[CornInt].SetActive(true);
        yield return new WaitForSeconds(0.5f);

        if (!cornChosen)
        {
            StartCoroutine(CornChooser());
        }
    }
    public IEnumerator FaceChooser()
    {
        choos = 4;
        if (FaceInt < plOneFace.Length)
        {
            FaceInt++;
        }
        if (FaceInt >= plOneFace.Length)
        {
            FaceInt = 0;
        }
        for (int i = 0; i < plOneFace.Length; i++)
        {
            plOneFace[i].SetActive(false);
        }
        plOneFace[FaceInt].SetActive(true);
        yield return new WaitForSeconds(0.5f);

        if (!faceChosen)
        {
            StartCoroutine(FaceChooser());
        }
    }
    public IEnumerator EyesChooser()
    {
        choos = 5;
        if (EyesInt < plOneEyes.Length)
        {
            EyesInt++;
        }
        if (EyesInt >= plOneEyes.Length)
        {
            EyesInt = 0;
        }
        for (int i = 0; i < plOneEyes.Length; i++)
        {
            plOneEyes[i].SetActive(false);
        }
        plOneEyes[EyesInt].SetActive(true);
        yield return new WaitForSeconds(0.5f);

        if (!eyesChosen)
        {
            StartCoroutine(EyesChooser());
        }
    }
}
