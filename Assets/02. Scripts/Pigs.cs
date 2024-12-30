using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigs : MonoBehaviour
{

    public bool isHit;
    
    
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
    }


    public void OnCollisionExit(Collision other)
    {

    }
}
