using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{ 
    public static PauseTime singleton;
    // Start is called before the first frame update
    void Awake()
    {
        if (singleton != null){
            Destroy(this.gameObject);
        }
        else{
            singleton = this;
        }

        startTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stopTime(){
        Time.timeScale = 0.00000001f;
        Time.fixedDeltaTime = .02f * 0.0000001f;
        //audioMixer.SetFloat("MasterPitch", 1);
    }
    public void startTime(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f;
        //audioMixer.SetFloat("MasterPitch", 1);
    }
}
