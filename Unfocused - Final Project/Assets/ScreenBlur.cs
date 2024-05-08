using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenBlur : MonoBehaviour
{
    [SerializeField] private float blurTime = 1;


    // Start is called before the first frame update
    void Start()
    {
        BlurIn();
    }

    // Update is called once per frame
    public void BlurIn(){

    }

    public void BlurOut(string newScene = ""){
        StartCoroutine(BlurOutRoutine());
        IEnumerator BlurOutRoutine(){
            float timer = 0;
            while(timer < blurTime){
                yield return null;
                timer+=Time.deltaTime;
                //fadeImage.color = new Color(fadeColor.r,fadeColor.g,fadeColor.b, (timer/blurTime));
            }
            //fadeImage.color = fadeColor;
            if(newScene != ""){
                    SceneManager.LoadScene(newScene);
            }
        }
    }
}
