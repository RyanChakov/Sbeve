using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnUI : MonoBehaviour
{
    public GameObject UI;
    public Camera cam1, cam2;
   void Start()
    {
        UI.SetActive(true);
        print("TEST");
     
    }
    private void Update()
    {
        cam1.enabled = false;
        cam2.enabled = true;
    }

}
