using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public DayNightCycle checkTOD;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRangeY = 5.5f;
    [SerializeField] public float spawnNumber = 5;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkTOD.setTime != checkTOD.DayTime){
            SpawnEnemy();
        }
        else{
            i = 0;
        }
        
    }

    void SpawnEnemy(){
        while(i < spawnNumber){
            SpawnEnemyRandom();
            i+=1;
        }
        
    }

    void SpawnEnemyRandom(){

        float randomY = Random.Range(-spawnRangeY,spawnRangeY);

        GameObject newEnemy = Instantiate(enemyPrefab,new Vector3(-11f, randomY, 0), Quaternion.identity);
        Destroy(newEnemy,checkTOD.nightTime);

    }
}
