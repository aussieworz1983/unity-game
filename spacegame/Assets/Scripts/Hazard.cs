using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    
    
    public int damage;
    
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
       hit=false;
       damage=100;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {        
            if(other){
               if(other.gameObject.transform.parent.gameObject.tag==("Player")&&hit==false){
               hit=true;
               GameObject player = other.gameObject.transform.parent.gameObject;
               Player playerScript = player.GetComponent<Player>();
               playerScript.Damage(damage);    
               }else if(other.gameObject.tag==("PlayerBullet")){

               Debug.Log("Bullet Hit");
               } else{
                 Debug.Log("Hazard hit "+other);
               }            
            Destroy(this.gameObject);
            }
           
        
           }
}
