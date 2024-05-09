using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DaysCountText; 
    public static DayCount singleton;
    [SerializeField] public DayNightCycle day;
    public int numDays;

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    void Update(){
        numDays = day.count;
        DaysCountText.text = (numDays).ToString();
    }

    public void RegisterCount(){
        

    }
}
