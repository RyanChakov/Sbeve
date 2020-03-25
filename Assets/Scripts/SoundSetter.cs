using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetter : MonoBehaviour
{
    public AudioSource footSteps, drill;
    private moving moving;
    private CharacterController player;
    private TerrainEditor driller;
    private Animator RobotAnim;
    public GameObject Cam;
    bool first = true;
    void Start()
    {
        moving = GetComponent<moving>();
        player = GetComponent<CharacterController>();
        RobotAnim = GetComponent<Animator>();
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
            if (Input.GetButton("Fire1") && driller.enabled)
            {
                drill.Play();
                if (first)
                {
                    RobotAnim.SetBool("Mining", true);
                    RobotAnim.Play("DrillingAnim");
                    first = false;
                }
            }
        }
        else if (drill.isPlaying && !Input.GetButton("Fire1")|| !driller.enabled)
        {
            RobotAnim.SetBool("Mining", false);
            first = true;
            drill.Stop();

        }
    }
}
