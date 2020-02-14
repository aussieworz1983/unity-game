using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer lR;
    public Material mat;
    public Vector2 offset;
    public int scrollSpeed;
    public int lengthOfLineRenderer = 20;
    public Vector3 startPos ;
    public Vector3 endPos ;
    public float dist;
    public float counter;
    public bool laserActive = false;
    public Transform laserMuzzle;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        lR = transform.GetComponent<LineRenderer>();
        lR.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));

        startPos = new Vector3(0.0f, 0.0f, 0.0f);
        endPos = new Vector3(0.0f,0.0f,0.0f-20);
        dist = Vector3.Distance(startPos,endPos);
        StartCoroutine(LaserTimer());
    }

    // Update is called once per frame
    void Update()
    {
       

        if (laserActive==true) {
            if (counter < dist)
            {
               
                counter += 0.1f;
                float z = Mathf.Lerp(0, dist, counter);
                Vector3 pointA = startPos;
                Vector3 pointB = endPos;

                Vector3 pointOnLaser = z * Vector3.Normalize(pointB - pointA) + pointA;

                lR.SetPosition(1, pointOnLaser);
           
            }
            RaycastHit hit;
            if (Physics.Raycast(laserMuzzle.position, laserMuzzle.TransformDirection(Vector3.forward) * 1000, out hit))
            {
                Debug.DrawRay(laserMuzzle.position, laserMuzzle.TransformDirection(Vector3.forward) * 1000, Color.red);
                Debug.Log("object hit " + hit.transform);
                if (hit.transform.gameObject.tag == "Player")
                {
                   Player player = hit.transform.gameObject.GetComponent<Player>();
                    player.Damage(damage);
                }
            }
            else
            {
                Debug.DrawRay(laserMuzzle.position, laserMuzzle.TransformDirection(Vector3.forward) * 1000, Color.white);
            }
        }
        else {
            lR.SetPosition(0, startPos);
            lR.SetPosition(1, startPos);
            counter = 0.0f;
        }


        mat = lR.material;
        offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime / scrollSpeed;
        mat.mainTextureOffset = offset;
        lR.SetWidth(5, 5);
        Debug.Log("laser");

    }
    IEnumerator LaserTimer () {
        while (true) {
            yield return new WaitForSeconds(10);
            laserActive = true;

            yield return new WaitForSeconds(15);
            laserActive = false;

        }
     

    }
    


}
