using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other!=null)
        {
            if (other.CompareTag("Player")) {
                Player player = other.gameObject.GetComponent<Player>(); ;
                if (player==null) {
                    player = other.gameObject.GetComponentInParent<Player>();
                    player.Damage(damage);
                }
                else {    
                    player.Damage(damage);
                }

            }
        }
    }
}
