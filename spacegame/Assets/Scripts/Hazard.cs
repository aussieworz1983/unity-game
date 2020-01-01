using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public int damage;
    public BoxCollider collider;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
       hit=false;
       damage=100;
       collider = transform.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
                        
 
            if(other.gameObject.transform.parent.gameObject.tag==("Player")&&hit==false){
               hit=true;
               GameObject player = other.gameObject.transform.parent.gameObject;
               Player playerScript = player.GetComponent<Player>();
               playerScript.Damage(damage);
               
                 Debug.Log("Player Hit");
            }
            Destroy(gameObject);
        
    }
}
