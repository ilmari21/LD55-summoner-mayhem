using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowGameTime : MonoBehaviour
{

    [SerializeField] TMP_Text text;

    void Start()
    {
        
    }

    public void DisplayTime(GameManager gm) {
        var time = gm.gameTimer;
        var timeText = time.ToString("F2");
        text.text = "Time: " + timeText + " s";
    }

}
