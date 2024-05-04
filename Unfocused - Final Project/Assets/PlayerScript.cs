using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public HealthBar bar;
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] public float currentHealth = 10f;
    [SerializeField] public float speed = 5;
    [SerializeField] public float damage = 0;

    [Header("Flavor")]
    [SerializeField] string PlayerName = "Player";
    [SerializeField] private GameObject body;
    //[SerializeField] private List<AnimationStateChanger> ;

    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;

    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthTracker(damage);
    }
    public void MovePlayer(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }


    public void PickupMaterials(){
        MaterialsCount.singleton.RegisterMaterial();
        //GetComponent<AudioSource>().Play();
    }
    public void HealthTracker(float damage){
        if(currentHealth > 0){
            bar.percentage = (currentHealth-damage)/maxHealth;
        }
        // else
        //     PlayerDeath();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Enemy>() != null){
            damage = other.GetComponent<Enemy>().damage;
            HealthTracker(damage);
        }
    }
    public void PlayerDeath(){

    }
}
