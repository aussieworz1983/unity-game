using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
   
     public GameObject hazard;
     public Vector3 spawnValues;
     public int hazardCount;
     public float spawnWaitTime;
     public float startWait;
     public float waveWait;
 
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
        yield return new WaitForSeconds(startWait);
        while(true){
      for(int i = 0; i < hazardCount; i++){
          Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
          Quaternion spawnRotation = Quaternion.identity;
          hazard = ObjectPool.SharedInstance.GetPooledObject("Hazard");
         if(hazard!=null){

           hazard.transform.position = spawnPosition;
         hazard.transform.rotation = spawnRotation;
         hazard.SetActive(true);

         }
        
         
       
      yield return new WaitForSeconds(spawnWaitTime);
      }
       
       yield return new WaitForSeconds(waveWait);
      }
     
       
         
       
     }
}
