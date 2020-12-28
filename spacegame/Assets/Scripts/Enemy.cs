using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Idamageable
{    
    public int health;
    public int maxHealth;
    public bool enemyShieldState;
    public bool alive;
    public int damage;
    public int enemyShieldHealth;
 
   
    // Start is called before the first frame update
  
    void Start()
    {
         enemyShieldState = false;
         alive = true;
         health = maxHealth;
        
    }
    void OnEnable()
    {

        alive = true;
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(health<0&&alive==true){
              Die();
        }
    }
    public void Damage(int damage){
        if (enemyShieldState==true) { 
        enemyShieldHealth -= damage;
        }
        else {
           health -= damage;
        }

    }
    public void Die(){
        alive=false;
        gameObject.SetActive(false);
    }
  
    
    
}
