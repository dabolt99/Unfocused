using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting : MonoBehaviour
{
    [SerializeField] MaterialsCount MCount;
    [SerializeField] private TextMeshProUGUI MaterialsCountText;
    [SerializeField] private TextMeshProUGUI wallPriceText;
    [SerializeField] private TextMeshProUGUI trapPriceText;
    [SerializeField] private TextMeshProUGUI pitPriceText;
    [SerializeField] public int wallCost = 5;
    [SerializeField] public int trapCost = 5;
    [SerializeField] public int pitCost = 5;

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
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
        wallPriceText.text = wallCost.ToString();
        trapPriceText.text = trapCost.ToString();
        pitPriceText.text = pitCost.ToString();
    }
    public void CraftWall(){
        if(MCount.materialsCollected >= wallCost){
            GameObject newWall = Instantiate(wallPrefab, mousePosition, Quaternion.identity);
            PurchaseItem(wallCost);
        }
    }
    public void CraftTrap(){
        
        if(MCount.materialsCollected >= trapCost){
            GameObject newTrap = Instantiate(trapPrefab, mousePosition, Quaternion.identity);
            PurchaseItem(trapCost);
        }
    }
    public void CraftPit(){
        
        if(MCount.materialsCollected >= pitCost){
            GameObject newPit = Instantiate(pitPrefab, mousePosition, Quaternion.identity);
            PurchaseItem(pitCost);
        }
    }
    public void PurchaseItem(int itemCost){
        MCount.materialsCollected = MCount.materialsCollected - itemCost;
        MaterialsCountText.text = MCount.materialsCollected.ToString();
    }
}
