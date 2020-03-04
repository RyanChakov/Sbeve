using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDestroy : MonoBehaviour
{
    public float timer, timerAmount = 2;
    void Update()
    {
        if (timer > timerAmount)
        {
            GameObject.FindWithTag("Destroy").GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
