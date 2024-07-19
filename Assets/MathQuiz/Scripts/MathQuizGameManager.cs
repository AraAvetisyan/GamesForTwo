using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

public class MathQuizGameManager : MonoBehaviour
{
    [SerializeField] private int partOne, partTwo;
    [SerializeField] string[] sign; // 0_+, 1_-, 2_*, 3_/
    [SerializeField] private int answer;
    [SerializeField] private int signInt;
    [SerializeField] private TextMeshProUGUI taskOne, taskTwo;

    [SerializeField] private int plOneButtonOneAnswer, plOneButtonTwoAnswer, plOneButtonThreeAnswer;
    [SerializeField] private int plTwoButtonOneAnswer, plTwoButtonTwoAnswer, plTwoButtonThreeAnswer;

    [SerializeField] private TextMeshProUGUI plOneButtonOneAnswerText, plOneButtonTwoAnswerText, plOneButtonThreeAnswerText;
    [SerializeField] private TextMeshProUGUI plTwoButtonOneAnswerText, plTwoButtonTwoAnswerText, plTwoButtonThreeAnswerText;
    [SerializeField] private Button plOneButtonOne, plOneButtonTwo, plOneButtonThree, plTwoButtonOne, plTwoButtonTwo, plTwoButtonThree;
    [SerializeField] private Image plOneButtonOneImage, plOneButtonTwoImage, plOneButtonThreeImage, plTwoButtonOneImage, plTwoButtonTwoImage, plTwoButtonThreeImage;

    [SerializeField] private int plOnePoints, plTwoPoints;
    [SerializeField] private TextMeshProUGUI plOnePointsText, plTwoPointsText;
    [SerializeField] private bool canPress;
    [SerializeField] private bool isSingle;
    [SerializeField] private bool isMobile;

    [SerializeField] private GameObject plOneWinPC, plTwoWinPC, plOneWinMobile, plTwoWinMobile;
    [SerializeField] private GameObject finalPanel;
    private bool singleCanChoose;
    private void Awake()
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
    void Start()
    {
        if(isMobile && !isSingle)
        {
            plTwoButtonOne.transform.rotation = Quaternion.Euler(0, 0, 180);
            plTwoButtonTwo.transform.rotation = Quaternion.Euler(0, 0, 180);
            plTwoButtonThree.transform.rotation = Quaternion.Euler(0, 0, 180);
            taskTwo.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        TaskCreator();
        StartCoroutine(Single());
        canPress = true;

       
    }

    void Update()
    {
        if(!isMobile)
        {
            if (canPress)
            {

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    PressedPlOneButtonOne();
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    PressedPlOneButtonTwo();
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    PressedPlOneButtonThree();
                }
                if (!isSingle)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        PressedPlTwoButtonOne();
                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        PressedPlTwoButtonTwo();
                    }

                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        PressedPlTwoButtonThree();
                    }
                }
            }
        }
        if(plOnePoints == 10)
        {
            if(isMobile && !isSingle)
            {
                plOneWinMobile.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
            else
            {
                plOneWinPC.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
        }
        if(plTwoPoints == 10)
        {
            if (isMobile && !isSingle)
            {
                plTwoWinMobile.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
            else
            {
                plTwoWinPC.SetActive(true);
                StartCoroutine(WaitToFinish());
            }
        }
    }
    public IEnumerator Single()
    {
        yield return new WaitForSecondsRealtime(3f);
        if (canPress)
        {
            singleCanChoose = true;
            SingleChooser();
        }

        if (plOnePoints != 10 && plTwoPoints != 10)
        {
            StartCoroutine(Single());
        }


    }
    public void SingleChooser()
    {
        int rand = Random.Range(0, 3);
        if (canPress)
        {
            if (rand == 0)
            {
                PressedPlTwoButtonOne();
            }
            if (rand == 1)
            {
                PressedPlTwoButtonTwo();
            }
            if (rand == 2)
            {
                PressedPlTwoButtonThree();
            }
        }
    }
    public IEnumerator WaitToFinish()
    {
        canPress = false;
        singleCanChoose = false;
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
    public void TaskCreator()
    {
        partOne = Random.Range(0, 100);
        partTwo = Random.Range(0, 100);
        if (partOne != partTwo)
        {
            signInt = Random.Range(0, 2);
            Debug.Log(signInt);
        }
        if (partOne == partTwo)
        {
            signInt = Random.Range(0, sign.Length);
        }
        if (signInt == 0)
        {
          //  Debug.Log("Gumarum");
            answer = partOne + partTwo;
        }
        if (signInt == 1)
        {
          //  Debug.Log("Hanum");
            answer = partOne - partTwo;
        }
        if (signInt == 2)
        {
         //   Debug.Log("bazmapatkum");
            answer = partTwo * partOne;
        }
        if (signInt == 3 && partOne % partTwo == 0)
        {
         //   Debug.Log("bajanum");
            answer = partOne / partTwo;
        }
        if (signInt == 3 && partOne % partTwo != 0)
        {
           
            answer = partOne + partTwo;
            signInt = 0;
        }
       

        int plOneRight = Random.Range(0, 3);
        int plTwoRight = Random.Range(0, 3);
        

        int plOneWrongeOne = Random.Range(answer / 2, answer * 2);
        int plOneWrongeTwo = Random.Range(answer / 2, answer * 2);
        if(plOneWrongeTwo == plOneWrongeOne)
        {
            plOneWrongeTwo = Random.Range(plOneWrongeOne * 5, answer * 15);
        }
        int plTwoWrongeOne = plOneWrongeOne;
        int plTwoWrongeTwo = plOneWrongeTwo;

        if(answer == 0)
        {
            plOneWrongeOne = Random.Range(1 , 10);
            plOneWrongeTwo = Random.Range(11 , 20);
        }
        if(answer == plOneWrongeOne)
        {
            plOneWrongeOne = Random.Range(1, 10);
        }
        if(answer == plOneWrongeTwo)
        {
            plOneWrongeTwo = Random.Range(11, 20);
        }
        taskOne.text = partOne.ToString() + " " + sign[signInt] + " " + partTwo.ToString();
        taskTwo.text = partOne.ToString() + " " + sign[signInt] + " " + partTwo.ToString();
        if (plOneRight == 0)
        {
            plOneButtonOneAnswer = answer;
            plOneButtonOneAnswerText.text = plOneButtonOneAnswer.ToString();
            plOneButtonTwoAnswerText.text = plOneWrongeOne.ToString();
            plOneButtonThreeAnswerText.text = plOneWrongeTwo.ToString();
        }
        if (plOneRight == 1)
        {
            plOneButtonTwoAnswer = answer;
            plOneButtonTwoAnswerText.text = plOneButtonTwoAnswer.ToString();
            plOneButtonOneAnswerText.text = plOneWrongeOne.ToString();
            plOneButtonThreeAnswerText.text = plOneWrongeTwo.ToString();

        }
        if (plOneRight == 2)
        {
            plOneButtonThreeAnswer = answer;
            plOneButtonThreeAnswerText.text = plOneButtonThreeAnswer.ToString();
            plOneButtonOneAnswerText.text = plOneWrongeOne.ToString();
            plOneButtonTwoAnswerText.text = plOneWrongeTwo.ToString();
        }


        if (plTwoRight == 0)
        {
            plTwoButtonOneAnswer = answer;
            plTwoButtonOneAnswerText.text = plTwoButtonOneAnswer.ToString();
            plTwoButtonTwoAnswerText.text = plTwoWrongeOne.ToString();
            plTwoButtonThreeAnswerText.text = plTwoWrongeTwo.ToString();
        }
        if (plTwoRight == 1)
        {
            plTwoButtonTwoAnswer = answer;
            plTwoButtonTwoAnswerText.text = plTwoButtonTwoAnswer.ToString();
            plTwoButtonOneAnswerText.text = plTwoWrongeOne.ToString();
            plTwoButtonThreeAnswerText.text = plTwoWrongeTwo.ToString();
        }
        if (plTwoRight == 2)
        {
            plTwoButtonThreeAnswer = answer;
            plTwoButtonThreeAnswerText.text = plTwoButtonThreeAnswer.ToString();
            plTwoButtonOneAnswerText.text = plTwoWrongeOne.ToString();
            plTwoButtonTwoAnswerText.text = plTwoWrongeTwo.ToString();
        }
       
    }


    public void PressedPlOneButtonOne()
    {
        StopCoroutine(Single());
        canPress = false;
        if (plOneButtonOneAnswer == answer)
        {
            plOnePoints += 1;
            plOnePointsText.text= plOnePoints.ToString();
            plOneButtonOneImage.color = Color.green;

        }
        else
        {
            plTwoPoints += 1;
            plTwoPointsText.text = plTwoPoints.ToString();
            plOneButtonOneImage.color = Color.red;
        }
        plOneButtonOne.interactable = false;
        plOneButtonTwo.interactable = false;
        plOneButtonThree.interactable = false;
        plTwoButtonOne.interactable = false;
        plTwoButtonTwo.interactable = false;
        plTwoButtonThree.interactable = false;
        StartCoroutine(NewTask());

    }
    public void PressedPlOneButtonTwo()
    {
        StopCoroutine(Single());
        canPress = false;
        if (plOneButtonTwoAnswer == answer)
        {
            plOnePoints += 1;
            plOnePointsText.text = plOnePoints.ToString();
            plOneButtonTwoImage.color = Color.green;

        }
        else
        {
            plTwoPoints += 1;
            plTwoPointsText.text = plTwoPoints.ToString();
            plOneButtonTwoImage.color = Color.red;
        }
        plOneButtonOne.interactable = false;
        plOneButtonTwo.interactable = false;
        plOneButtonThree.interactable = false;
        plTwoButtonOne.interactable = false;
        plTwoButtonTwo.interactable = false;
        plTwoButtonThree.interactable = false;
        StartCoroutine(NewTask());
    }
    public void PressedPlOneButtonThree()
    {
        StopCoroutine(Single());
        canPress = false;
        if (plOneButtonThreeAnswer == answer)
        {
            plOnePoints += 1;
            plOnePointsText.text = plOnePoints.ToString();
            plOneButtonThreeImage.color = Color.green;

        }
        else
        {
            plTwoPoints += 1;
            plTwoPointsText.text = plTwoPoints.ToString();
            plOneButtonThreeImage.color = Color.red;
        }
        plOneButtonOne.interactable = false;
        plOneButtonTwo.interactable = false;
        plOneButtonThree.interactable = false;
        plTwoButtonOne.interactable = false;
        plTwoButtonTwo.interactable = false;
        plTwoButtonThree.interactable = false;
        StartCoroutine(NewTask());
    }
    public void PressedPlTwoButtonOne()
    {
        StopCoroutine(Single());
        canPress = false;
        if (plTwoButtonOneAnswer == answer)
        {
            plTwoPoints += 1;
            plTwoPointsText.text = plTwoPoints.ToString();
            plTwoButtonOneImage.color = Color.green;

        }
        else
        {
            plOnePoints += 1;
            plOnePointsText.text = plOnePoints.ToString();
            plTwoButtonOneImage.color = Color.red;
        }
        plOneButtonOne.interactable = false;
        plOneButtonTwo.interactable = false;
        plOneButtonThree.interactable = false;
        plTwoButtonOne.interactable = false;
        plTwoButtonTwo.interactable = false;
        plTwoButtonThree.interactable = false;
        StartCoroutine(NewTask());
    }
    public void PressedPlTwoButtonTwo()
    {
        StopCoroutine(Single());
        canPress = false;
        if (plTwoButtonTwoAnswer == answer)
        {
            plTwoPoints += 1;
            plTwoPointsText.text = plTwoPoints.ToString();
            plTwoButtonTwoImage.color = Color.green;

        }
        else
        {
            plOnePoints += 1;
            plOnePointsText.text = plOnePoints.ToString();
            plTwoButtonTwoImage.color = Color.red;
        }
        plOneButtonOne.interactable = false;
        plOneButtonTwo.interactable = false;
        plOneButtonThree.interactable = false;
        plTwoButtonOne.interactable = false;
        plTwoButtonTwo.interactable = false;
        plTwoButtonThree.interactable = false;
        StartCoroutine(NewTask());
    }
    public void PressedPlTwoButtonThree()
    {
        StopCoroutine(Single());
        canPress = false;
        if (plTwoButtonThreeAnswer == answer)
        {
            plTwoPoints += 1;
            plTwoPointsText.text = plTwoPoints.ToString();
            plTwoButtonThreeImage.color = Color.green;

        }
        else
        {
            plOnePoints += 1;
            plOnePointsText.text = plOnePoints.ToString();
            plTwoButtonThreeImage.color = Color.red;
        }
        plOneButtonOne.interactable = false;
        plOneButtonTwo.interactable = false;
        plOneButtonThree.interactable = false;
        plTwoButtonOne.interactable = false;
        plTwoButtonTwo.interactable = false;
        plTwoButtonThree.interactable = false;
        StartCoroutine(NewTask());
    }
    public IEnumerator NewTask()
    {
        yield return new WaitForSeconds(1.5f);
        plOneButtonOne.interactable = true;
        plOneButtonTwo.interactable = true;
        plOneButtonThree.interactable = true;
        plTwoButtonOne.interactable = true;
        plTwoButtonTwo.interactable = true;
        plTwoButtonThree.interactable = true;
        plOneButtonOneImage.color = Color.white;
        plOneButtonTwoImage.color = Color.white;
        plOneButtonThreeImage.color = Color.white;
        plTwoButtonOneImage.color = Color.white;
        plTwoButtonTwoImage.color = Color.white;
        plTwoButtonThreeImage.color = Color.white;
        canPress = true;
        if (plOnePoints != 10 && plTwoPoints != 10)
        {
            TaskCreator();           
        }
    }
}
