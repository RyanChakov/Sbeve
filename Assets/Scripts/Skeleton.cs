using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
public class Skeleton : MonoBehaviour
{
    public moving player;
    bool idle = false;
    float timerT = .75f;
    float timer = .78f;
    public Animator Skel;
    public RectTransform hBar;
    float bLength=.4f;
    float bPosX = 204;
    public Transform target;
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
            bPosX -= 17.1f;
           hBar.localScale = new Vector3(bLength,.09f,1);
            hBar.transform.position = new Vector3(bPosX, -38, 0);
        }
        else
        {
            print(timer);
            timer -= Time.deltaTime;
        }

    }
}

