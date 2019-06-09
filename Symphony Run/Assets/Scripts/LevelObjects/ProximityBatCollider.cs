﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityBatCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<BatScript>().moveToThePlayer();
        }
    }
}
