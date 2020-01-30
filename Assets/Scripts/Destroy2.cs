using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.blue);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, maxDistance, mask))
        {
            print("THERE IS GROUND");
            
        }



    }
}
