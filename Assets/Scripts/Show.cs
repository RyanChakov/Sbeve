using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public FreeCam FC;
    public GameObject JetPack;
    public GameObject Robot;
    public PickUp money;
    public moving health;
    void Update()
    {
        money = Robot.GetComponentInChildren<PickUp>();
        health = Robot.GetComponentInChildren<moving>();
    }
    public void ShowIt(GameObject anything)
    {
        anything.SetActive(true);
        
    }
    public void UnShowIt(GameObject anything)
    {
        anything.SetActive(false);

    }
    public void Closing()
    {
        FC.looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Heal2(float healthAddCost)
    {
        //super weird bug cant pass multiples things through to the first number is heal added the next 3 numbers are the cost
        
        float cost = healthAddCost%1000;
        float healthAdd = (healthAddCost - cost) / 1000;
        if (cost <= money.money)
        {
            money.Buy(cost);
            print("This is the health:" + healthAdd + " and this is the cost:" + cost);
            health.Health(-healthAdd);
        }

    }
    public void Shield(float healthAddCost)
    {
        //super weird bug cant pass multiples things through to the first number is heal added the next 3 numbers are the cost

        float cost = healthAddCost % 1000;
        float healthAdd = (healthAddCost - cost) / 1000;
        if (cost <= money.money)
        {
            money.Buy(cost);
            print("This is the health:" + healthAdd + " and this is the cost:" + cost);
            health.Shield(healthAdd);
        }

    }
    public void JetPackOn(float cost)
    {
       

        
        if (cost <= money.money)
        {
            money.Buy(cost);
            health.JetOn = true;
           JetPack.SetActive(true);
            
            
        }

    }
}
