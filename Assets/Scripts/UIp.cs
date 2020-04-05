using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIp : MonoBehaviour
{
    public FreeCam FC;
    public GameObject EText;
    public GameObject Inventory;
    public GameObject Shop;
    public GameObject cam;
    public GameObject esc;
    RaycastHit hit = new RaycastHit();
    RaycastHit hitT = new RaycastHit();
    public AudioSource click;
    public TerrainEditor terr;
    public bool picPickUp=false,jetPickUp=false;
    // Update is called once per frame
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Shop.activeSelf || esc.activeSelf)
        {
            terr.enabled = false;
            if (Input.GetMouseButton(0))
            {
                click.Play();
            }
        }
        else if (!Shop.activeSelf && !esc.activeSelf && !terr.enabled)
        {
            terr.enabled = true;
        }
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
                    //EText.SetActive(false);
                    Shop.SetActive(!Shop.activeSelf);
                }
                else if(hit.collider.transform.parent.name == "picaxe")
                {
                    hit.collider.transform.parent.gameObject.SetActive(false);
                    picPickUp = true;
                }
                else if (hit.collider.transform.parent.name == "JetpackPick")
                {
                    hit.collider.transform.parent.gameObject.SetActive(false);
                    jetPickUp = true;
                }
                if (Shop.activeSelf)
                {
                    FC.looking = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    FC.looking = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Inventory.activeSelf || Shop.activeSelf || esc.activeSelf)
            {
                FC.looking = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Inventory.SetActive(false);
                Shop.SetActive(false);
                esc.SetActive(false);
            }
            else
            {
                FC.looking = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                esc.SetActive(true);
            }
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hitT, 10f))
        {
            if (hitT.collider.gameObject.layer == 16 || hitT.collider.gameObject.layer == 9 || hitT.collider.name == "Slime")
            {
                EText.SetActive(true);
            }
            else
            {
                EText.SetActive(false);
            }
        }
        else
        {
            EText.SetActive(false);
        }
    }
}
