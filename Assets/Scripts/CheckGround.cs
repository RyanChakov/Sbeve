using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    const int DISAPEAR_DIST = 5;
    RaycastHit hit = new RaycastHit();
    RaycastHit hit1 = new RaycastHit();
    float timer = 3f,time=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ned = new Vector3(transform.position.x, transform.position.y + DISAPEAR_DIST, transform.position.z);
        Debug.DrawRay(ned, transform.TransformDirection(Vector3.down) * 2*DISAPEAR_DIST, Color.blue);
        if (time > timer)
        {
            LayerMask mask = LayerMask.GetMask("Ground");


            if (!Physics.Raycast(ned, transform.TransformDirection(Vector3.down), out hit1, 2*DISAPEAR_DIST, mask))
            {
                Destroy(gameObject);
            }
           
        }
        else
        {

            time += Time.deltaTime;
        }

        LayerMask mask2 = LayerMask.GetMask("Enemies");

        Vector3 ned2 = new Vector3(transform.position.x, transform.position.y - DISAPEAR_DIST, transform.position.z);
        if (Physics.Raycast(ned2, transform.TransformDirection(Vector3.up), out hit1, 2 * DISAPEAR_DIST, mask2))
        {
            Destroy(gameObject);
        }

    }
}
