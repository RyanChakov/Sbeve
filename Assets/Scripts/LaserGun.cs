using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{

    public Transform reticle, lowerArm;

    // Update is called once per frame
    void Update()
    {
        lowerArm.LookAt(reticle);
    }
}
