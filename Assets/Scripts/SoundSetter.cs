using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetter : MonoBehaviour
{
    public AudioSource footSteps, drill;
    private moving moving;
    private CharacterController player;
    private TerrainEditor driller;
    void Start()
    {
        moving = GetComponent<moving>();
        player = GetComponent<CharacterController>();

        driller = GetComponentInChildren<TerrainEditor>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!footSteps.isPlaying)
        {
            if (player.velocity.x > 0)
            {
                footSteps.Play();
            }
        }
        if (!drill.isPlaying)
        {
            if (Input.GetButton("Fire1") && driller.enabled && driller.eye1.activeSelf)
            { 
                drill.Play();
            }
            else if(!driller.eye1.activeSelf)
            {
                drill.Stop();
            }
        }
        else if (drill.isPlaying && !Input.GetButton("Fire1") || !driller.eye1.activeSelf)
        {
            drill.Stop();
           
        }
        else if(!driller.enabled)
        {
            drill.Stop();
           
        }
    }
}
