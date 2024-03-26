using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandlers : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;
    [SerializeField] private ScreenSlider screenSlider;
    public enum ScreenChangeMethod {fade, slide};
    [SerializeField] ScreenChangeMethod changeMethod = ScreenChangeMethod.fade;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        //SceneManager.LoadScene("Game");
        if(changeMethod == ScreenChangeMethod.fade){
            screenFader.FadeToColor("Game");
        }
        else if(changeMethod == ScreenChangeMethod.slide){
            screenSlider.SlideToColor("Game");
        }
    }

    public void Quit(){
        Application.Quit();
    }
}
