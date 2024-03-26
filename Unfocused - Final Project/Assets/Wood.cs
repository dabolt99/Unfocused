using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerScript>() != null){
            other.GetComponent<PlayerScript>().PickupMaterials();
            Destroy(this.gameObject);
        }
    }
}
