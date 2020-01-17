using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Skeleton : MonoBehaviour
{
    public moving player;
    bool idle = false;
    float timerT = .78f;
    float timer = .78f;
    public Animator Skel;
    public Animator Robot;
    public RectTransform hBar;
    float bLength=.4f; 
    public Transform target;
    public GameObject free;
    public ChangeCamera cC;
    // Update is called once per frame
    void Update()
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
    void attack()
    {
        
        print("ATTACKING");
        if(timer<=0)
        {
            player.Phealth -= .1f;
            print("This is the player Health" + player.Phealth);
            timer = timerT;
    
            bLength -= .04f;
            if (bLength <= 0)
            {
                bLength = 0;
                Robot.enabled = true;

                Robot.SetTrigger("Dead");
                Robot.GetComponentInParent<moving>().enabled = false;
                Robot.GetComponentInParent<CharacterController>().enabled = false;
                free.GetComponent<FreeCam>().enabled = false;
                cC.dead = true;

            }
          
           
           hBar.localScale = new Vector3(bLength,.09f,1);
           
        }
        else
        {
            
            print(timer);
            timer -= Time.deltaTime;
        }

    }
}

