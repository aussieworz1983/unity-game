using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public GameObject projectile;
    public Transform muzzle;
    public AudioClip shotSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(){
       if(Time.time > nextFire){
            nextFire = Time.time + fireRate;
            AudioOneShot();
            Fire();
            GameManager.SharedInstance.shotsFired += 1;
            
            
       }
        
    }
    public void AudioOneShot(){
        audioSource.PlayOneShot(shotSound);
    }
    public void Fire(){
          projectile = ObjectPool.SharedInstance.GetPooledObject("PlayerBullet"); 
         if (projectile != null) {
            projectile.transform.position = muzzle.transform.position;
            projectile.transform.rotation = muzzle.transform.rotation;
            projectile.SetActive(true);
          }
             //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
    }
}
