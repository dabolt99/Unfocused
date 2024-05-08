using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncreaseDays : MonoBehaviour
{
    [SerializeField] public DayNightCycle checkDays;
    [SerializeField] private TextMeshProUGUI DaysText; 
    int numDays;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numDays = checkDays.count;
        DaysText.text = numDays.ToString();
    }
}
