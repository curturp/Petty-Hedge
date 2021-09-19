using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Made using the help of Brackeys Tutorials - https://www.youtube.com/user/Brackeys

    public TextMeshProUGUI timeScore;

    private void OnEnable()
    {
        timeScore.text = GameManager.TimeScore.ToString("F2");
    }
}
