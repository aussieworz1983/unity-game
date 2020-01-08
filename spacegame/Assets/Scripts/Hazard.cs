using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    
    public GameObject effect;
    public int damage;
    
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
       
       damage=100;
       
    }

    private void OnTriggerEnter(Collider other)
    {        
            if(other!=null){
               Idamageable damageableObj = other.gameObject.GetComponentInParent<Idamageable>();
               if(damageableObj!=null){
                  damageableObj.Damage(damage);
                   
                  
                  effect = Instantiate(effect, transform.position, Quaternion.identity) as GameObject;
                  gameObject.SetActive(false);
               }else{
                gameObject.SetActive(false);
                 effect = Instantiate(effect, transform.position, Quaternion.Euler(90,0,0)) as GameObject;
               }          
             
            }
           
        
           }
}
