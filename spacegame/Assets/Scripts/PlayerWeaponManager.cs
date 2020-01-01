﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public Weapon[] weapon;
    public GameObject activeWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
        weapon[0]=transform.GetChild(1).GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f")){
          Debug.Log("shoot");
          weapon[0].Shoot();
        }
    }
}