using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Transform playerTransform;
    [SerializeField] Vector3 homePosition = Vector3.zero;
    [SerializeField] public Vector2 currentPosition;
    [SerializeField] private float acumulatedDamage = 0f;
    [SerializeField] public PauseTime pause;

    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        pause.startTime();
    }

    // Update is called once per frame
    void Update()
    {
        HealthTracker(damage);
        currentPosition = playerTransform.localPosition;
    }
    public void MovePlayer(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }


    public void PickupMaterials(){
        GetComponent<AudioSource>().Play();
        MaterialsCount.singleton.RegisterMaterial();
    }
    public void HealthTracker(float damage){
        acumulatedDamage = acumulatedDamage + damage;
        currentHealth = maxHealth - acumulatedDamage;
        bar.percentage = currentHealth/maxHealth;
        if(currentHealth < 0){
            PlayerDeath("End Game");
        }
    }
    
    public void PlayerDeath(string newScene = ""){
        if(newScene != ""){
                pause.stopTime();
                SceneManager.LoadScene(newScene);                
            }
    }
}
