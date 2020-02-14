using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Idamageable
{
    public int health;
    public int maxHealth;
    public int ships;
    public bool isDead;
    public GameObject playerObj;
    public bool playerInvincible;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {  
      
      maxHealth=100;
       health=maxHealth;
       isDead=false;
       ships=3;
       playerObj=transform.GetChild(0).gameObject;
       StartCoroutine(MyUpdate());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void IsDead(){
     
     playerObj.SetActive(false);
     health=maxHealth;
     ships -= 1;
     GameManager.SharedInstance.cashLost += 50;
     GameManager.SharedInstance.UpdateGui();
     if(ships>=0){
      StartCoroutine(RespawnWait());
     }else{
       
      }
     
    }
    public void Damage (int damage){
        if(!isDead&&!playerInvincible){
            health -= damage;
         }
        
    }
    public void AddShip(){
        ships+=1;
        GameManager.SharedInstance.UpdateGui();
    }
    public void ActivateInvincible(){
       playerInvincible=true;
       StartCoroutine(Invincibility());
     }
    IEnumerator RespawnWait(){
       
       yield  return new WaitForSeconds(2);     
       playerObj.SetActive(true);
       isDead=false;
        StartCoroutine(MyUpdate());
     }
     IEnumerator MyUpdate(){
      while(!isDead){
        
         if(health<=0&&isDead==false){
            Debug.Log("Player Dead");
            isDead=true;
            IsDead();
        }
      yield  return new WaitForSeconds(0.1f); 
     }
        
          
     
      
     }
    IEnumerator Invincibility(){

      
      
      yield return new WaitForSeconds(30);
      
      playerInvincible=false;

    }
    
}
