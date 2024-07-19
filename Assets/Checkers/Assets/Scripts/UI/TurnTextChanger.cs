using TMPro;
using UnityEngine;

public class TurnTextChanger : MonoBehaviour
{
    private TextMeshProUGUI turnText;
    private Animator textAnimator;

    private void Start()
    {
        turnText = GetComponent<TextMeshProUGUI>();
        textAnimator = GetComponent<Animator>();
    }

    public void ChangeTurnText(int turn)
    {
        if (turn == 0)
        {
            if (Geekplay.Instance.language == "ru")
            {
                turnText.text = "очередь черных";
            }
            else if (Geekplay.Instance.language == "en")
            {
                turnText.text = "Black`s turn";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                turnText.text = "siyahın sırası";
            }
            
        }
        if (turn == 1)
        {
            if (Geekplay.Instance.language == "ru")
            {
                turnText.text = "очередь белых";
            }
            else if (Geekplay.Instance.language == "en")
            {
                turnText.text = "White`s turn";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                turnText.text = "beyaz sirasi";
            }
        }
        //turnText.text = pawnColor.ToString().ToUpper() + "'S TURN";
        textAnimator.SetTrigger("NextTurn");
    }
}