using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class PickUp : MonoBehaviour
{
    
    public int dice;
    public int rollDice;
    public string type;
    public double extraCashLow;
    public double extraCashHigh;
    
    // Start is called before the first frame update
    void Start()
    {
        dice = 6;
        rollDice=Random.Range(0,dice);
        switch(rollDice){
          case 0:
            ExtraCashLow();
           break;
          case 1: 
            ExtraLife();
            break;
          case 2:
            ExtraCashHigh();
            break;
          case 3:
            Invincibility();
            break;
          case 4:
            Drone();
            break;
          case 5:
            ExtraBomb();
            break;
          }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
         Debug.Log("Player hit");
         
         try{
             Player playerObj = other.gameObject.GetComponent<Player>();
            if(playerObj==null){
             playerObj = other.gameObject.GetComponentInParent<Player>();
              }
            
            AddBonus(playerObj);
          }catch(Exception e){
              Debug.Log("player trigger null "+e);
           }
         
           Destroy(gameObject);
         }else if(other.gameObject.tag=="PlayerBullet"){
           Destroy(gameObject);
         }
     }
    void AddBonus(Player player){
        if(type=="ExtraCashLow"){
          GameManager.SharedInstance.AddPlayerCash(extraCashLow);
        
        }else if(type=="ExtraLife"){
          player.AddShip();
        }else if(type == "ExtraCashHigh"){
          GameManager.SharedInstance.AddPlayerCash(extraCashHigh);
        }else if(type == "Invincibility"){
          player.ActivateInvincible();
          
        }
        else if(type == "Drone"){
          Debug.Log("Activate Drone");
        }else if(type == "ExtraBomb"){
          Debug.Log("Extra Bomb");
        }
     }
    void ExtraCashLow(){
         type = "ExtraCashLow";
         extraCashLow = Random.Range(2,10);
     }
    void ExtraLife(){
         type = "ExtraLife";
     }
    void ExtraCashHigh(){
         type = "ExtraCashHigh";
         extraCashHigh = Random.Range(10,50);
     }
    void Invincibility(){
         type = "Invincibility";

     }
    void Drone(){
         type = "Drone";
     }
    void ExtraBomb(){
         type = "ExtraBomb";
     }
}
