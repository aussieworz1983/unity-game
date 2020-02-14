using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
     Rigidbody asteroidRigidbody;
     void Start() {
         asteroidRigidbody = GetComponent<Rigidbody> ();
         asteroidRigidbody.angularVelocity = Random.insideUnitSphere * tumble;
     }
}
