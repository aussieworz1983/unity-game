using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
   
     public GameObject hazard;
     public Vector3 spawnValues;
     public int hazardCount;
     public int waitTime;
 
     void SpawnWaves() {
         
           StartCoroutine(SpawnTimer()); 
         
     }
     void Update(){
       if(hazardCount==0){
          //down to last spawn
          
       }
     }
     void Start() {
         SpawnWaves ();
     }
        IEnumerator SpawnTimer(){
        while(hazardCount>=0){
       Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
       Quaternion spawnRotation = Quaternion.identity;
       Instantiate (hazard, spawnPosition, spawnRotation);
       hazardCount -= 1;
       yield return new WaitForSeconds(waitTime);
         }
       
     }
}
