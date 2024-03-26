using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health = 10;
    [SerializeField] public float speed = 5;

    public enum PlayerMovementType { tf, physics };
    [SerializeField] PlayerMovementType movementType = PlayerMovementType.tf;

    [Header("Physics")]
    [SerializeField] LayerMask groundMask;

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
        if (movementType == PlayerMovementType.tf)
        {
            MovePlayerTransform(direction);
        }
        else if (movementType == PlayerMovementType.physics)
        {
            MovePlayerRb(direction);
        }


    }

    public void MovePlayerRb(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (currentVelocity) + (direction * speed);
        /*if(rb.velocity.x<0){
            body.transform.localScale = new Vector3(-1,1,1);
        }
        else(rb.velocity.x>0){
            body.transform.localScale = new Vector3(1,1,1);
        }*/
        //rb.AddForce(direction * speed);
        //rb.MovePosition(transform.position + (direction * speed * Time.deltaTime))
    }

    public void MovePlayerTransform(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    // public void Jump()
    // {
    //     if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0),jumpRadius,groundMask).Length > 0){
    //         rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    //     }

    // }
}
