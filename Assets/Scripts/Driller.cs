﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driller : MonoBehaviour
{
    public Transform main;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            this.transform.RotateAround(main.position, transform.parent.transform.up, 20);
        //  this.transform.Rotate(new Vector3(0, 90, 0), Space.Self);
    }
}
