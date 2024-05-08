using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    [SerializeField] MaterialsCount MCount;
    [SerializeField] public int itemCost = 5;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private GameObject pitPrefab;
    [SerializeField] public Vector3 mousePosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void CraftWall(){
        if(MCount.materialsCollected > itemCost){
            GameObject newWall = Instantiate(wallPrefab, mousePosition, Quaternion.identity);
            MCount.materialsCollected = MCount.materialsCollected - itemCost;
        }
    }
    public void CraftTrap(){
        
        if(MCount.materialsCollected > itemCost){
            GameObject newTrap = Instantiate(trapPrefab, mousePosition, Quaternion.identity);
            MCount.materialsCollected = MCount.materialsCollected - itemCost;
        }
    }
    public void CraftPit(){
        
        if(MCount.materialsCollected > itemCost){
            GameObject newPit = Instantiate(pitPrefab, mousePosition, Quaternion.identity);
            MCount.materialsCollected = MCount.materialsCollected - itemCost;
        }
    }
}
