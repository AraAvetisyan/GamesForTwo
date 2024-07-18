using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerGameLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerPlOnePC, winnerPlOneMobile, winnerPlTwo;
    [SerializeField] private TextMeshProUGUI diferencePlOne, diferencePlTwo;
    [SerializeField] private TextMeshProUGUI targetTimePlOne, targetTimePlTwo;
    [SerializeField] private TextMeshProUGUI stopTheTimerAt, seconds;


    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            winnerPlOnePC.text = "ПОБЕДИТЕЛЬ";
            winnerPlOneMobile.text = "ПОБЕДИТЕЛЬ";
            winnerPlTwo.text = "ПОБЕДИТЕЛЬ";
            diferencePlOne.text = "Разница";
            diferencePlTwo.text = "Разница";
            targetTimePlOne.text = "Целевое время";
            targetTimePlTwo.text = "Целевое время";
            stopTheTimerAt.text = "Остановите таймер на";
            seconds.text = "секунде";

        }
        else if (Geekplay.Instance.language == "en")
        {
            winnerPlOnePC.text = "WINNER";
            winnerPlOneMobile.text = "WINNER";
            winnerPlTwo.text = "WINNER";
            diferencePlOne.text = "DIFERENCE";
            diferencePlTwo.text = "DIFERENCE";
            targetTimePlOne.text = "TARGET TIME";
            targetTimePlTwo.text = "TARGET TIME";
            stopTheTimerAt.text = "STOP THE TIMER AT";
            seconds.text = "SECONDS";

        }
        else if (Geekplay.Instance.language == "tr")
        {
            winnerPlOnePC.text = "Kazanan";
            winnerPlOneMobile.text = "Kazanan";
            winnerPlTwo.text = "Kazanan";
            diferencePlOne.text = "Farklılık";
            diferencePlTwo.text = "Farklılık";
            targetTimePlOne.text = "Hedef Zaman";
            targetTimePlTwo.text = "Hedef Zaman";
            stopTheTimerAt.text = "zamanlayıcıyı durdur";
            seconds.text = "saniye";
        }
    }
}
