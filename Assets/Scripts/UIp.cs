using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIp : MonoBehaviour
{
    public FreeCam FC;
   public GameObject Inventory;
    public GameObject Shop;
    public GameObject cam;
    RaycastHit hit = new RaycastHit();
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
            {
                if (hit.collider.name == "Knight")
                {
                    Shop.SetActive(!Shop.activeSelf);
                }
                if (Shop.activeSelf)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
    
}
