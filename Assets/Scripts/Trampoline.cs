using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Transform end;
    public Transform start;
    public moving health;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Trampoline")
        {

            transform.position = new Vector3(end.position.x + 10, end.position.y + 10, end.position.z);

        }

        if (hit.collider.tag == "Teleporter")
        {

            transform.position = new Vector3(start.position.x + 10, start.position.y + 10, start.position.z);

        }

        if (hit.collider.tag == "Death")
        {

            health.Health(100);
        }


    }
}
