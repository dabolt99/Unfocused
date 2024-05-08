using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandlers : MonoBehaviour
{
    [SerializeField] private ScreenBlur screenBlur;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        screenBlur.BlurOut("Game");
    }

    public void Quit(){
        Application.Quit();
    }
}
