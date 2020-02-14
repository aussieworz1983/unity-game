using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.tag=="PlayerBullet"){
               other.gameObject.SetActive(false);
               GameManager.SharedInstance.shotsMissed += 1;
               GameManager.SharedInstance.cashLost += 1;
               GameManager.SharedInstance.UpdateGui();
            }
           
    }
}
