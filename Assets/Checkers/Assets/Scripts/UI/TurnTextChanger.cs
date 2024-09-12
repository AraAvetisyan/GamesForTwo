using TMPro;
using UnityEngine;

public class TurnTextChanger : MonoBehaviour
{
    private TextMeshProUGUI turnText;
    private Animator textAnimator;

    private void Start()
    {
        Geekplay.Instance.GameReady();
        turnText = GetComponent<TextMeshProUGUI>();
        textAnimator = GetComponent<Animator>();
    }

    public void ChangeTurnText(int turn)
    {
        if (turn == 0)
        {
            if (Geekplay.Instance.language == "ru")
            {
                turnText.text = "Очередь Синих";
            }
            else if (Geekplay.Instance.language == "en")
            {
                turnText.text = "Blue`s Turn";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                turnText.text = "Mavi dönüş";
            }
            
        }
        if (turn == 1)
        {
            if (Geekplay.Instance.language == "ru")
            {
                turnText.text = "Очередь Красных";
            }
            else if (Geekplay.Instance.language == "en")
            {
                turnText.text = "Red`s Turn";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                turnText.text = "Kırmızılar Dönüyor";
            }
        }
        //turnText.text = pawnColor.ToString().ToUpper() + "'S TURN";
        textAnimator.SetTrigger("NextTurn");
    }
}