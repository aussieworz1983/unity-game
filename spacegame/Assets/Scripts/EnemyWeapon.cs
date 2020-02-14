using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float lowRate = 3.0F;
    public float highRate = 1.0F;
    private float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public GameObject projectile;
    public Transform muzzle;
    public AudioClip shotSound;
    AudioSource audioSource;

   
    // Start is called before the first frame update
    void Start()
    {
        fireRate = Random.Range(lowRate,highRate);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Shoot());
    }
    void OnEnable() {
        fireRate = Random.Range(lowRate, highRate);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator Shoot(){
        while (true) {

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                AudioOneShot();
                Fire();

            }
            yield return new WaitForSeconds(0.5f);
        }
      
     
        
    }
    public void AudioOneShot()
    {
        audioSource.PlayOneShot(shotSound);
    }
    public void Fire()
    {
        projectile = ObjectPool.SharedInstance.GetPooledObject("EnemyBullet");
        if (projectile != null)
        {
            projectile.transform.position = muzzle.transform.position;
            projectile.transform.rotation = muzzle.transform.rotation;
            projectile.SetActive(true);
        }
        //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
    }
}
