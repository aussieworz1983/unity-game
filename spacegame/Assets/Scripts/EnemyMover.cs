using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody enemyRigidbody;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.velocity = Vector3.forward * speed;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
