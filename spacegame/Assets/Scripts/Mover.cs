using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody boltRigidbody;
     public float speed;
     public float highSpeed;
     public float lowSpeed;
     void Start(){
         speed = Random.Range(lowSpeed,highSpeed);
         boltRigidbody = GetComponent<Rigidbody> ();
         boltRigidbody.velocity = Vector3.forward * speed;
 
     }
}
