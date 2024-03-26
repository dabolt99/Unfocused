using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockTime;
    [SerializeField] public DayNightCycle setTimer; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clockTime.text = setTimer.timer.ToString();
    }
}
