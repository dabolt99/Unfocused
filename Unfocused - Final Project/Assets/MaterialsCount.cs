using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaterialsCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MaterialsCountText; 
    public static MaterialsCount singleton;
    [SerializeField]public int materialsCollected = 0;

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    void Start(){
        
    }

    public void RegisterMaterial(){
        materialsCollected += 1;
        MaterialsCountText.text = (materialsCollected/2).ToString();

    }
}
