﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
