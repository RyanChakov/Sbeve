using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    
    public GameObject anything;
    public GameObject Robot;
    public float money;
    public moving health;
    void Update()
    {
        money = Robot.GetComponentInChildren<PickUp>().totalmoney;
        health = Robot.GetComponentInChildren<moving>();
    }
    public void ShowIt()
    {
        anything.SetActive(true);
        
    }
    public void UnShowIt()
    {
        anything.SetActive(false);

    }
    public void Heal2(float healthAddCost)
    {
        //super weird bug cant pass multiples things through to the first number is heal added the next 3 numbers are the cost
        
        float cost = healthAddCost%1000;
        float healthAdd = (healthAddCost - cost) / 1000;
        if (cost <= money)
        {
            money -= cost;
            print("This is the health:" + healthAdd + " and this is the cost:" + cost);
            health.Health(-healthAdd);
        }

    }
}
