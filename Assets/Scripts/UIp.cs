using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIp : MonoBehaviour
{
   public GameObject Inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
}
