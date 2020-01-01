using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    public int damage;
void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
    }
}
