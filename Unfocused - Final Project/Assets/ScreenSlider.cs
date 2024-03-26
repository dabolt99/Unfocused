using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenSlider : MonoBehaviour
{
    [SerializeField] private Image slideImage;
    [SerializeField] private Color slideColor = Color.white;
    [SerializeField] private float slideTime = 1;
    [SerializeField] Vector3 homePosition = Vector3.zero;
    [SerializeField] Vector3 newPosition = new Vector3(0,-450,0);

    void Start()
    {
        SlideToClear();
    }

    void SlideToClear(){
        slideImage.color = slideColor;
        StartCoroutine(SlideToClearRoutine());
        IEnumerator SlideToClearRoutine(){
            float timer = 0;
            while(timer < slideTime){
                yield return null;
                timer+=Time.deltaTime;
                transform.localPosition = Vector3.Lerp(homePosition, newPosition, timer/slideTime);
                //slideImage.color = new Color(slideColor.r,slideColor.g,slideColor.b, 1f - (timer/slideTime));
            }
            transform.localPosition = newPosition;
        }
    }

    public void SlideToColor(string newScene = ""){
        
        StartCoroutine(SlideToColorRoutine());
        IEnumerator SlideToColorRoutine(){
            float timer = 0;
            while(timer < slideTime){
                yield return null;
                timer+=Time.deltaTime;
                transform.localPosition = Vector3.Lerp(newPosition, homePosition, timer/slideTime);

            }
            transform.localPosition = homePosition;
            if(newScene != ""){
                SceneManager.LoadScene(newScene);
            }
        }
    }
}