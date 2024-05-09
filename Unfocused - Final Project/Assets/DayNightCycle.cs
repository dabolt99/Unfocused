using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    public enum CurrentTime {day, night};
    [SerializeField] public CurrentTime setTime = CurrentTime.day;
    [SerializeField] public CurrentTime DayTime = CurrentTime.day;

    [SerializeField] public float dayTime = 16f;
    public float nightTime;
    [SerializeField] public float timer;
    [SerializeField] public float minutes = 30f;
    [SerializeField] public int count;

    public static DayNightCycle singleton = null;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if(singleton == null){
            singleton = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        nightTime = 24f - dayTime;
        if(setTime == CurrentTime.day){
            StartTimer(dayTime);
        }
        else if(setTime == CurrentTime.night){
            StartTimer(nightTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }

    void StartTimer(float startTime){
        timer = (startTime * minutes);
        RunTimer();
    }

    void ChangeTime(){
        if(setTime == CurrentTime.day){
            setTime = CurrentTime.night;
            StartTimer(nightTime);
        }
        else if(setTime == CurrentTime.night){
            setTime = CurrentTime.day;
            count++;
            StartTimer(dayTime);
        }
    }
    void RunTimer(){
        timer = timer - Time.deltaTime;
        if(timer <= 0f){
            ChangeTime();
        }
    }
}
