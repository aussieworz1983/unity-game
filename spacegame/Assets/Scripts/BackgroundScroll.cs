 ﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{   public MeshRenderer mR;
    public Material mat;
    public Vector2 offset;
    public int scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
      mR = transform.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         mat = mR.material;
         offset = mat.mainTextureOffset;
         offset.y += Time.deltaTime / scrollSpeed;
         mat.mainTextureOffset = offset;
    }
}
