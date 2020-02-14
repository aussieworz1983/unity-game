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
 public void AddScore(){
     GameManager.SharedInstance.playerCash += 5;
     GameManager.SharedInstance.shotsHit += 1;
     GameManager.SharedInstance.UpdateGui();
   }
 private void OnTriggerEnter(Collider other)
    {
     if(other!=null){
       if(other.gameObject.tag=="Hazard"){
       AddScore();
       this.gameObject.SetActive(false);
      }
     if(other.gameObject.tag=="Enemy"){
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy==null) {
                     enemy = other.gameObject.GetComponentInParent<Enemy>();
                }
                enemy.Damage(damage);
                this.gameObject.SetActive(false);
            }

       }
  
   
    
    
    }

}
