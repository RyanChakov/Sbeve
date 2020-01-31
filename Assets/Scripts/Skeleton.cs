using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Pathfinding;
public class Skeleton : MonoBehaviour
{
    public moving player;
    bool idle = false;
    float timerT = .78f;
    float timer = .78f;
    float Dtimer = 4f;
    public float SHelath=10;
    public Animator Skel;
    public Animator Robot;
  
    public Transform target;
    
 
    // Update is called once per frame
    void Update()
    {
        if(SHelath!=0)
        { 
            if (Vector3.Distance(transform.position, target.position) >= 4f)
            {
                Skel.SetTrigger("running");
            }
            else if (Vector3.Distance(transform.position, target.position) < 4f)
            {
                Skel.enabled = false;
                Skel.enabled = true;
                Skel.SetTrigger("Attacking");
                Skel.ResetTrigger("running");
                attack();
            }
        }
        else
        {
            Skel.Play("SkeletonArmature|Skeleton_Death");
            GetComponent<AIPath>().enabled = false;
            if (Dtimer <= 0)
            {

                Destroy(this.gameObject);
            }
            else
            {


                Dtimer -= Time.deltaTime;
            }
            
        }

    }
    void attack()
    {
        
       
        if(timer<=0)
        {
            player.Health(1);
           if(player.Phealth<=0)
            {
                Skel.Play("SkeletonArmature|Skeleton_Idle");
            }
            timer = timerT;
        }
        else
        {
            

            timer -= Time.deltaTime;
        }

    }
}

