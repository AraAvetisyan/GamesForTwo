using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneChooser : MonoBehaviour
{
    [SerializeField] private UnicornChooser _unicornChooser;
    public int counter;
    private int choos;
    [SerializeField] private GameObject[] plOneHeadMobile, plOneHairMobile, plOneCornMobile, plOneFaceMobile, plOneEyesMobile;
    [SerializeField] private GameObject[] plOneHeadPC, plOneHairPC, plOneCornPC, plOneFacePC, plOneEyesPC;
    public int HeadInt, HairInt, CornInt, FaceInt, EyesInt;
    private bool headChosen, hairChosen, cornChosen, faceChosen, eyesChosen;
    public bool PlayerOneEnds;
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
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            buttonBG.SetActive(false);
            if (!IsSingle)
            {
                //buttonOne.SetActive(false);
                //buttonTwo.SetActive(false);
                //buttonBG.SetActive(false);
            }
        }

    }
   
    // Update is called once per frame
    void Update()
    {
        if (!IsMobile && Input.GetKeyDown(KeyCode.M) && !IsSingle)
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
            if (IsSingle)
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
            if (IsSingle)
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
            if (IsSingle)
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
            if (IsSingle)
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
            if (IsSingle)
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
        if (IsMobile && !IsSingle)
        {
            Debug.Log("Mobile Head");
            if (HeadInt < plOneHeadMobile.Length)
            {
                HeadInt++;
            }
            if (HeadInt >= plOneHeadMobile.Length)
            {
                HeadInt = 0;
            }
            for (int i = 0; i < plOneHeadMobile.Length; i++)
            {
                plOneHeadMobile[i].SetActive(false);
            }
            plOneHeadMobile[HeadInt].SetActive(true);
        }
        if(!IsMobile || IsSingle)
        {
            Debug.Log("PC Head");
            if (HeadInt < plOneHeadPC.Length)
            {
                HeadInt++;
            }
            if (HeadInt >= plOneHeadPC.Length)
            {
                HeadInt = 0;
            }
            for (int i = 0; i < plOneHeadPC.Length; i++)
            {
                plOneHeadPC[i].SetActive(false);
            }
            plOneHeadPC[HeadInt].SetActive(true);
        }
        yield return new WaitForSeconds(1f);

        if (!headChosen)
        {
            StartCoroutine(HeadChooser());
        }
    }
    public IEnumerator HairChooser()
    {
        choos = 2;
        if (IsMobile && !IsSingle)
        {
            if (HairInt < plOneHairMobile.Length)
            {
                HairInt++;
            }
            if (HairInt >= plOneHairMobile.Length)
            {
                HairInt = 0;
            }
            for (int i = 0; i < plOneHairMobile.Length; i++)
            {
                plOneHairMobile[i].SetActive(false);
            }
            plOneHairMobile[HairInt].SetActive(true);
        }
        if (!IsMobile || IsSingle)
        {
            if (HairInt < plOneHairPC.Length)
            {
                HairInt++;
            }
            if (HairInt >= plOneHairPC.Length)
            {
                HairInt = 0;
            }
            for (int i = 0; i < plOneHairPC.Length; i++)
            {
                plOneHairPC[i].SetActive(false);
            }
            plOneHairPC[HairInt].SetActive(true);
        }
       
        yield return new WaitForSeconds(1f);

        if (!hairChosen)
        {
            StartCoroutine(HairChooser());
        }
    }
    public IEnumerator CornChooser()
    {
        choos = 3;
        if (IsMobile && !IsSingle)
        {
            if (CornInt < plOneCornMobile.Length)
            {
                CornInt++;
            }
            if (CornInt >= plOneCornMobile.Length)
            {
                CornInt = 0;
            }
            for (int i = 0; i < plOneCornMobile.Length; i++)
            {
                plOneCornMobile[i].SetActive(false);
            }
            plOneCornMobile[CornInt].SetActive(true);
        }
        if (!IsMobile || IsSingle)
        {
            if (CornInt < plOneCornPC.Length)
            {
                CornInt++;
            }
            if (CornInt >= plOneCornPC.Length)
            {
                CornInt = 0;
            }
            for (int i = 0; i < plOneCornPC.Length; i++)
            {
                plOneCornPC[i].SetActive(false);
            }
            plOneCornPC[CornInt].SetActive(true);
        }
        yield return new WaitForSeconds(1f);

        if (!cornChosen)
        {
            StartCoroutine(CornChooser());
        }
    }
    public IEnumerator FaceChooser()
    {
        choos = 4;
        if (IsMobile && !IsSingle)
        {
            if (FaceInt < plOneFaceMobile.Length)
            {
                FaceInt++;
            }
            if (FaceInt >= plOneFaceMobile.Length)
            {
                FaceInt = 0;
            }
            for (int i = 0; i < plOneFaceMobile.Length; i++)
            {
                plOneFaceMobile[i].SetActive(false);
            }
            plOneFaceMobile[FaceInt].SetActive(true);
        }
        if (!IsMobile || IsSingle)
        {
            if (FaceInt < plOneFacePC.Length)
            {
                FaceInt++;
            }
            if (FaceInt >= plOneFacePC.Length)
            {
                FaceInt = 0;
            }
            for (int i = 0; i < plOneFacePC.Length; i++)
            {
                plOneFacePC[i].SetActive(false);
            }
            plOneFacePC[FaceInt].SetActive(true);
        }
        yield return new WaitForSeconds(1f);

        if (!faceChosen)
        {
            StartCoroutine(FaceChooser());
        }
    }
    public IEnumerator EyesChooser()
    {
        choos = 5;
        if (IsMobile && !IsSingle)
        {
            if (EyesInt < plOneEyesMobile.Length)
            {
                EyesInt++;
            }
            if (EyesInt >= plOneEyesMobile.Length)
            {
                EyesInt = 0;
            }
            for (int i = 0; i < plOneEyesMobile.Length; i++)
            {
                plOneEyesMobile[i].SetActive(false);
            }
            plOneEyesMobile[EyesInt].SetActive(true);
        }
        if (!IsMobile || IsSingle)
        {
            if (EyesInt < plOneEyesPC.Length)
            {
                EyesInt++;
            }
            if (EyesInt >= plOneEyesPC.Length)
            {
                EyesInt = 0;
            }
            for (int i = 0; i < plOneEyesPC.Length; i++)
            {
                plOneEyesPC[i].SetActive(false);
            }
            plOneEyesPC[EyesInt].SetActive(true);
        }
        yield return new WaitForSeconds(1f);

        if (!eyesChosen)
        {
            StartCoroutine(EyesChooser());
        }
    }
}
