using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public bool dead;
    public Camera mainCam;
    public Camera deadCam;
    public GameObject start, end;
    public Transform player;
    public float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(dead)
        {
            mainCam.enabled = false;
            deadCam.enabled = true;
            //deadCam.transform.position = end.transform.position;

            
            deadCam.transform.position = Vector3.Lerp(start.transform.position, end.transform.position, 2.5f);
            deadCam.transform.LookAt(player);
           
        }
    }
}
