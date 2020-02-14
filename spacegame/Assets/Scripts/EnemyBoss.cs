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
    public GameObject forceField;

    // Start is called before the first frame update
    void Start()
    {
        laserRay.SetActive(false);
        health = 5000;
        enemyShieldHealth = 5000;
        enemyShieldState = true;
        enemyForceField.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyShieldHealth96*+-) {
        
          }
        if (transform.position.z <= targetPos.z)
        {
            speed = 0;
            if (moving==false) {
                StartCoroutine(Movement());
                moving = true;
            }


        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        }

    }
    IEnumerator Movement() {
        bool moveRight = false;
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
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            }
            else {
                speed = 0.09f;
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            }




            yield return new WaitForSeconds(0.01f);
        }
      
   }
    IEnumerator ActivateShield() {
        yield return new WaitForSeconds(1);
    }

}
