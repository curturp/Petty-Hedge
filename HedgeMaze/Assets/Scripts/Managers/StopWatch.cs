using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StopWatch : MonoBehaviour
{
    // Made using the help of Brackeys Tutorials - https://www.youtube.com/user/Brackeys

    public float timeStart;
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI startBtnText;

    public bool timerActive;


    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            timerActive = false;
            return;
        }

        if (!GameManager.GameStart)
        {
            timerActive = false;
            return;
        }

        if (timerActive)
        {
            timeStart += Time.deltaTime;
            GameManager.TimeScore += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
        }        
        
    }
    public void timerButton()
    {
        timerActive = !timerActive;
        startBtnText.text = timerActive ? "Pause Game" : "Start Game";
    }

    public void AltTimerButton()
    {
        timerActive = false;
        startBtnText.text = "Start Game";
    }
}
