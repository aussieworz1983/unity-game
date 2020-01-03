using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    public int damage;
void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * force);
    }

    void FixedUpdate()
    {
        
    }
 private void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.tag=="Hazard"){
     GameManager.SharedInstance.playerCash += 5;
     other.gameObject.SetActive(false);
     this.gameObject.SetActive(false);
      }
    
    
    }
}
