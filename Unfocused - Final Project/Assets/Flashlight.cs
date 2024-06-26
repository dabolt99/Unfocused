using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] public Transform parentTransform;
    [SerializeField] public Transform childTransform;

    [SerializeField] private Vector3 homePosition = new Vector3 (0, 0, 0);

    void Update()
    {
        childTransform.localPosition = parentTransform.localPosition;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;

        float angle = Vector2.SignedAngle(Vector2.down, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);

    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Enemy>() != null){
            other.GetComponent<Enemy>().speed = 1;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.GetComponent<Enemy>() != null){
            other.GetComponent<Enemy>().speed = other.GetComponent<Enemy>().topSpeed;
        }
    }
}
