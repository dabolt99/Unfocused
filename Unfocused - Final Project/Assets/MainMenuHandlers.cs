using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandlers : MonoBehaviour
{
    [SerializeField] private ScreenBlur screenBlur;
    [SerializeField] public PauseTime pause;
    // Start is called before the first frame update
    void Start()
    {
        pause.startTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        SceneManager.LoadScene("Game");
        //screenBlur.BlurOut("Game");
    }

    public void Quit(){
        Application.Quit();
    }
}
