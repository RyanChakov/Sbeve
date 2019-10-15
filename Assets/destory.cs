using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour
{
    [SerializeField] private World world;
    // Start is called before the first frame update
    void Start()
    {
        world.SetDensity(0, 0, 0, 0, true, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
