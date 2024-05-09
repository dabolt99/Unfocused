using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] public AudioSource shutter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Retry(){
        shutter.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit(){
        shutter.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
