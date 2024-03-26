using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeOfDay; 
    [SerializeField] public DayNightCycle setTOD;
    public static TextChanger singleton;

    // void Awake(){
    //     if(singleton != null){
    //         Destroy(this.gameObject);
    //     }
    //     singleton = this;
    // }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(setTOD.setTime == setTOD.DayTime){
            timeOfDay.text = "Daytime Remaining:";
        }
        else{
            timeOfDay.text = "Nighttime Remaining:";
        }
    }
}
