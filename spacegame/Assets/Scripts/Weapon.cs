using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public GameObject projectile;
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
            Debug.Log("Weapon shot");
       }
        
    }
    public void AudioOneShot(){
        audioSource.PlayOneShot(shotSound);
    }
}
