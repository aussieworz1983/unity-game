using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int ships;
    public bool isDead;
    public GameObject playerObj;
    
    
    // Start is called before the first frame update
    void Start()
    {
       isDead=false;
       ships=3;
       maxHealth=100;
       health=maxHealth;
       playerObj=transform.GetChild(0).gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0){
            Debug.Log("Player Dead");
            isDead=true;
            IsDead();
        }
    }
    void IsDead(){
     
     playerObj.SetActive(false);
     health=maxHealth;
     ships = -1;
      if(isDead==true){
         StartCoroutine(RespawnWait());
        
      }
     
     

    }
    void Damage (int damage ){
        health = -damage;
    }
    IEnumerator RespawnWait(){
       
      yield  return new WaitForSeconds(5);     
       playerObj.SetActive(true);
       isDead=false;
      
     }
    
}
