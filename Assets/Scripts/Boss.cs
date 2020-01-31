using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Animations;
public class Boss : MonoBehaviour
{
    public GameObject pillar;
    public GameObject Castle;
    public GameObject robot;
    public float bHealth=50;
    float Dtimer=5f;
    float Ctimer = 7f;
    float deadT = 20f;
    float aTimer = .7f;
    public bool attackPhase;
    bool attacking=false;
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
            if (bHealth != 0)
            {
                if (Vector3.Distance(transform.position, robot.transform.position) >= 32f)
                {
                    attacking = false;
                    GetComponent<Animator>().Play("Armature|Slime_Walk");
                }
                else if (Vector3.Distance(transform.position, robot.transform.position) < 32f)
                {
                    if(!attacking)
                    { 
                    GetComponent<Animator>().enabled = false;
                    GetComponent<Animator>().enabled = true;
                        attacking = true;
                    }
                  
                  
                    if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).speed != .5)
                        GetComponent<Animator>().Play("Armature|Slime_Attack");
                    if (aTimer <= 0)
                    {
                        robot.GetComponent<moving>().Health(5);
                        aTimer = .7f;
                        if (robot.GetComponent<moving>().Phealth <= 0)
                        {
                            GetComponent<Animator>().Play("Armature|Slime_Idle");
                        }
                    }
                    else
                    {
                        aTimer -= Time.deltaTime;
                    }
                   

                }
            }
            else
            {
                GetComponent<Animator>().Play("Armature|Slime_Death");
                GetComponent<AIPath>().enabled = false;
                if (deadT <= 0)
                {

                    Destroy(this.gameObject);
                }
                else
                {
                    if (transform.localScale.x >= 1.2)
                    {
                        this.transform.localScale -= new Vector3(Time.deltaTime * 2, Time.deltaTime * 2, Time.deltaTime * 2);
                    }
                    deadT -= Time.deltaTime;
                }

            }
           
        }
    }
}
