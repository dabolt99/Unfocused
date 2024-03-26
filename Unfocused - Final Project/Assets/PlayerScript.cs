using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health = 10;
    [SerializeField] public float speed = 5;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MovePlayer(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }


    public void PickupMaterials(){
        MaterialsCount.singleton.RegisterMaterial();
        //GetComponent<AudioSource>().Play();
    }
}
