using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedObstacles : MonoBehaviour
{
    public Transform obstacleTransform;
    [SerializeField] public Vector3 currentPosition;
    [SerializeField] public DayNightCycle checkTOD;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] public GameObject wallPrefab;
    [SerializeField] public GameObject trapPrefab;
    [SerializeField] public GameObject pitPrefab;
    private int nights = 0;
    private enum Placed {t, f}
    private Placed atNight = Placed.f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition=obstacleTransform.localPosition;
        ObstacleToMonster();
    }
    public void ObstacleToMonster(){
        if(checkTOD.setTime != checkTOD.DayTime){
            if(nights > 0){
                GameObject newEnemy = Instantiate(enemyPrefab, currentPosition, Quaternion.identity);
                Destroy(newEnemy,checkTOD.nightTime);
                nights = 0;
                atNight = Placed.f;
                Destroy(this.gameObject);
            }
            else{
                atNight = Placed.t;
            }
            
        }
        else if(checkTOD.setTime == checkTOD.DayTime){
            if(atNight == Placed.t){
                nights++;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Enemy>() != null){
            // if(this.GameObject == pitPrefab){

            // }
            // else if(this.GameObject == trapPrefab){
                
            // }
            // for(int i = 0; i < damageCooldown * Time.deltaTime; i++){
            //     damage = 0;
            // }
            // damage = baseDamage;

            
            //other.GetComponent<PlayerScript>().DamageCooldown();
        }
    }

}
