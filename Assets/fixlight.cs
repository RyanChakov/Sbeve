using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixlight : MonoBehaviour
{
    public float slows=0;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y<=110)
        {
            print("tes DID IT WORK");
            RenderSettings.ambientIntensity = Mathf.Lerp(.5f, .2f, slows);
            slows += 1 / 2 * Time.deltaTime;
        }
    }
}
