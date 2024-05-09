using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Enemy enemy;
    [SerializeField] public EnemySpawner eSpawn;
    [SerializeField] public DayNightCycle DNC;
    void Start()
    {
        //Normal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Easy(){
        enemy.baseDamage = 1;
        eSpawn.spawnNumber = 5;
        DNC.dayTime = 16f;
        Reset();
    }
    public void Normal(){
        enemy.baseDamage = 5;
        eSpawn.spawnNumber = 10;
        DNC.dayTime = 12f;
        Reset();
    }
    public void Hard(){
        enemy.baseDamage = 10;
        eSpawn.spawnNumber = 20;
        DNC.dayTime = 8f;
        Reset();
    }
    void Reset(){
        DNC.count = 1;
        DNC.setTime = DNC.DayTime;
        DNC.timer = 0;
        Destroy(enemy);
    }
}
