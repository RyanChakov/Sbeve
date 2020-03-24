using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public bool pic1 = false, pic2 = false, pic3 = false;
    public FreeCam FC;
    public GameObject JetPack;
    public GameObject Robot;
    public PickUp money;
    public moving health;
    public AudioSource purchase, notenough;
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

        float cost = healthAddCost % 1000;
        float healthAdd = (healthAddCost - cost) / 1000;
        if (cost <= money.totalmoney)
        {
            money.Buy(cost);
            print("This is the health:" + healthAdd + " and this is the cost:" + cost);
            health.Health(-healthAdd);
            Audio(purchase);
        }
        else
        {
            Audio(notenough);
        }

    }
    public void Shield(float healthAddCost)
    {
        //super weird bug cant pass multiples things through to the first number is heal added the next 3 numbers are the cost

        float cost = healthAddCost % 1000;
        float healthAdd = (healthAddCost - cost) / 1000;
        if (cost <= money.totalmoney)
        {
            money.Buy(cost);
            print("This is the health:" + healthAdd + " and this is the cost:" + cost);
            health.Shield(healthAdd);
            Audio(purchase);
        }
        else
        {
            Audio(notenough);
        }

    }
    public void JetPackOn(float cost)
    {



        if (cost <= money.totalmoney)
        {
            money.Buy(cost);
            health.JetOn = true;
            JetPack.SetActive(true);


            Audio(purchase);
        }
        else
        {
            Audio(notenough);
        }

    }
    public void Audio(AudioSource sound)
    {
        sound.Play();
    }
    public void Picaxe(float picAddCost)
    {
       
        float cost = picAddCost % 1000;
        float amount = (picAddCost - cost) / 1000;
        if (cost <= money.totalmoney)
        {
            switch (amount)
            {
                case 1:
                    pic1 = true;
                    break;
                case 2:
                    pic2 = true;
                    break;
                case 3:
                    pic3 = true;
                    break;
            }

            money.Buy(cost);
            Audio(purchase);
        }
        else
        {
            Audio(notenough);
        }

    }
}
