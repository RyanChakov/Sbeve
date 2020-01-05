using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

  
   
  
    public bool idle = false;
   
    public Animator Skel;
  
    public Transform target;
    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, target.position) >= 3f)
        {
            Skel.SetTrigger("running");
        }
        else if (Vector3.Distance(transform.position, target.position) < 3f)
        {
            Skel.SetTrigger("Attacking");
            Skel.ResetTrigger("running");
            attack();
        }
        
    }
    void attack()
    {


    }
}

