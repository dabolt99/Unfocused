using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawner : MonoBehaviour
{
    [SerializeField] public DayNightCycle checkTOD;
    [SerializeField] private GameObject MaterialsPrefab;
    [SerializeField] private float spawnRangeY = 5.5f;
    [SerializeField] private float spawnRangeX = 11f;
    [SerializeField] private float spawnNumber = 20;
    private int i = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(checkTOD.setTime == checkTOD.DayTime){
            SpawnMaterials();
        }
        else{
            i = 0;
        }
    }
    void SpawnMaterials(){
        while(i < spawnNumber){
            SpawnMaterialsRandom();
            i+=1;
        }
        
    }

    void SpawnMaterialsRandom(){

        float randomX = Random.Range(-spawnRangeX,spawnRangeX);
        float randomY = Random.Range(-spawnRangeY,spawnRangeY);

        GameObject newMaterials = Instantiate(MaterialsPrefab,new Vector3(randomX, randomY, 0), Quaternion.identity);
        //Destroy(newMaterials,10 * dropRate);

    }
}

