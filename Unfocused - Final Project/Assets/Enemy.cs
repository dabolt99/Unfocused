using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; 

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public float damage = 10f;
    [SerializeField] public float speed = 3f;
    [SerializeField] public float damageCooldown = 2f;
    
    [Header("Pathfinder")]
    Pathfinder<Vector2> pathfinder; 
    [SerializeField] LayerMask obstacles;
    [SerializeField] bool searchShortcut =false; 
    [SerializeField] bool snapToGrid =false; 
    Vector2 targetNode; 
    List <Vector2> path;
    List<Vector2> pathLeftToGo= new List<Vector2>();
    [SerializeField] bool drawDebugLines;

    [Header("Day/Night")]
    [SerializeField] DayNightCycle checkTOD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(checkTOD.setTime == checkTOD.DayTime){
        //     Destroy(this.gameObject);
        // }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerScript>() != null){
            other.GetComponent<PlayerScript>().HealthTracker(damage);
            for(int i = 0; i < damageCooldown * Time.deltaTime; i++){
                damage = 0;
            }
            //other.GetComponent<PlayerScript>().DamageCooldown();
        }
    }

    void MovementCont(){

    }
}
