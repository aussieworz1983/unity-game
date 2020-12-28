using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public GameObject enemy;
     public Vector3 spawnValues;
     public int enemyCount;
     public float spawnWaitTime;
     public float startWait;
     public float waveWait;
 
     void SpawnWaves() {
         
           StartCoroutine(SpawnTimer()); 
         
     }
     void Update(){
       if(enemyCount==0){
          //down to last spawn
          
       }
     }
     void Start() {
         SpawnWaves ();
     }
        IEnumerator SpawnTimer(){
        yield return new WaitForSeconds(startWait);
        while(true){
      for(int i = 0; i < enemyCount; i++){
          Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
                Quaternion spawnRotation = Quaternion.Euler(0.0F,180.0F,0.0F);
                enemy = ObjectPool.SharedInstance.GetPooledObject("Enemy");
                if (enemy!=null) {
                    enemy.transform.position = spawnPosition;
                    enemy.transform.rotation = spawnRotation;
                    enemy.SetActive(true);
                }

         
       
      yield return new WaitForSeconds(spawnWaitTime);
      }
       
       yield return new WaitForSeconds(waveWait);
      }
     
       
         
       
     }
}
