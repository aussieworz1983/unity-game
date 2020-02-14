using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeAi : MonoBehaviour
{
    public float movement;
    public float smoothing;
    public float tilt;
    public Vector2 moveStartWait;
    public Vector2 moveTime;
    public Vector2 moveWait;
    public Boundary boundary;

    public float currentSpeed;
    private float targetMovement;
     Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody> ();
        currentSpeed = rb.velocity.z;
        StartCoroutine (Evade ());
    }
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }
    IEnumerator Evade()
    {
         
        yield return new WaitForSeconds (Random.Range (moveStartWait.x, moveStartWait.y));
     
        while (true)
        {
            targetMovement = Random.Range (1, movement) * -Mathf.Sign (transform.position.x);
            yield return new WaitForSeconds (Random.Range (moveTime.x, moveTime.y));
            targetMovement = 0;
            yield return new WaitForSeconds (Random.Range (moveWait.x, moveWait.y));
        }
    }

    void FixedUpdate ()
    {
        float newMove = Mathf.MoveTowards (rb.velocity.x, targetMovement, Time.deltaTime * smoothing);
        rb.velocity = new Vector3 (newMove, 0.0f, currentSpeed);
        rb.position = new Vector3 
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler (0.0f, 180.0f, rb.velocity.x * -tilt);
    }
}
