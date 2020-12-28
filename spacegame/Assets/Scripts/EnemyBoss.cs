using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public float speed = 0.3f;
    public Vector3 targetPos = new Vector3(0.0f,0.0f,0.0f);
    public bool moving = false;
    public Boundary boundary;
   
    public GameObject laserRay;
    public GameObject enemyForceField;
    public bool moveRight = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        laserRay.SetActive(false);
        health = 5000;
        enemyShieldHealth = 5000;
        enemyShieldState = true;
        enemyForceField.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.z+targetPos.z);
        if (enemyShieldHealth<=0) {
        
          }
       

        }
    void FixedUpdate() {
        if (transform.position.z <= targetPos.z)
        {
            speed = 0;
            if (moving == false)
            {
                StartCoroutine(Movement());
                //moveRight = false;
                Debug.Log(transform.position.z);
            }


        }
        else
        {
            rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime);
        }

    }
    IEnumerator Movement() {
        
        while (true) {
            speed = 0.1f;

           
               
            if (transform.position.x >= 20) {
                moveRight = false;
            }
            else if (transform.position.x <= -20)
            {
                moveRight = true;
            }
            if (moveRight == true) {
                speed = 0.09f;
                rb.MovePosition(transform.position + -transform.right * Time.fixedDeltaTime);
            }
            else {
                speed = 0.09f;
                
                rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
            }
            



            yield return new WaitForSeconds(0.00f);
        }
      
   }
    IEnumerator ActivateShield() {
        yield return new WaitForSeconds(1);
    }

}
