using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Boss : MonoBehaviour
{
    public GameObject pillar;
    public GameObject Castle;
    public GameObject robot;
    float Dtimer=5f;
    float Ctimer = 10f;
    public bool attackPhase;
    void Update()
    {
       // transform.LookAt(robot.transform);
        if(transform.localScale.x >= 11 && pillar.activeSelf)
        {
            //Run animation
            //Some Code
            if (Dtimer <= 0)
            {

                pillar.SetActive(false);
            }
            else
            {
                Dtimer -= Time.deltaTime;
                pillar.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            }
           

        }
        if (transform.localScale.x >= 17 && Castle.activeSelf)
        {
            //Run animation
            //Some Code
            if (Ctimer <= 0)
            {
                Castle.SetActive(false);
                attackPhase = true;
            }
            else
            {
                Ctimer -= Time.deltaTime;
                Castle.transform.localScale -= new Vector3(Time.deltaTime/10, Time.deltaTime/10, Time.deltaTime/10);
            }
        }
        if(attackPhase)
        {
            GetComponent<AIPath>().canMove = true;
            GetComponent<Animator>().Play("Armature|Slime_Walk");
        }
    }
}
