using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();
    float timer = 2f,time=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time>timer)
        { 
            LayerMask mask = LayerMask.GetMask("Ground");


            if ((!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f)))
            {
                Destroy(gameObject);
            }
            else if ((!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 1f)))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            print(time);
            time += Time.deltaTime;
        }
    }
}
