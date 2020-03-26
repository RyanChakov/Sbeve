using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRessIns : MonoBehaviour
{
   private float timer=0;
    public Rigidbody head,body;
    
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
           
            GetComponent<Animator>().Play("BowPull");
          
        }
        if(Input.GetKey(KeyCode.U))
        {
            timer += Time.deltaTime;
          
        }
        if(Input.GetKeyUp(KeyCode.U))
        {
            if(timer>1)
            {
                timer = 1;
            }
            GetComponent<Animator>().Play("BowPull 0",0,1-timer);
            shoot();
        }
       
    }
    public void shoot()
    {
        body.isKinematic = false;
        head.isKinematic = false;

        head.AddForce(head.gameObject.transform.forward * 500*(1+timer));
    }
}
