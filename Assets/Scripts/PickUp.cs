using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();
    public int amberCount = 0, amethystCount = 0, aquamarineCount = 0, coalCount = 0, copperCount = 0, emeraldCount = 0, garnetCount = 0, goldCount = 0, lapisCount = 0, obsidianCount = 0, pearlCount = 0, rubyCount = 0, smokyCount = 0, money = 0, totalmoney = 0;
    public float newScale = 0;
    public GameObject slime;
    void Update()
    {

        GameObject test;
        LayerMask mask = LayerMask.GetMask("Ore");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f))
            {
                if (hit.collider.gameObject.layer == 9)
                {
                    switch (hit.collider.tag)
                    {
                        case "Amber":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            amberCount++;
                            break;
                        case "Amethyst":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            amethystCount++;
                            break;
                        case "Aquamarine":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            aquamarineCount++;
                            break;
                        case "Coal":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            coalCount++;
                            break;
                        case "Copper":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            copperCount++;
                            break;
                        case "Emerald":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            emeraldCount++;
                            break;
                        case "Garnet":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            garnetCount++;
                            break;
                        case "Gold":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            goldCount++;
                            break;
                        case "Lapis":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            lapisCount++;
                            break;
                        case "Obsidian":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            obsidianCount++;
                            break;
                        case "Pearl":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            pearlCount++;
                            break;
                        case "Ruby":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            rubyCount++;
                            break;
                        case "SmokyQuartz":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            smokyCount++;
                            break;
                    }

                }
                else if (hit.collider.name == "Slime")
                {
                    money = (amberCount * 20) + (amethystCount * 20) + (aquamarineCount * 20) + (coalCount * 10) + (copperCount * 20) + (emeraldCount * 30) + (garnetCount * 20) + (goldCount * 50) + (lapisCount * 20) + (obsidianCount * 20) + (pearlCount * 20) + (rubyCount * 40) + (smokyCount * 20);
                    totalmoney += money;
                    amberCount = amethystCount = aquamarineCount = coalCount = copperCount = emeraldCount = garnetCount = goldCount = lapisCount = obsidianCount = pearlCount = rubyCount = smokyCount = 0;
                    print("here");

                    print(money);
                    slime.transform.localScale += new Vector3(money / 200, money / 200, money / 200);

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            print(string.Format("Money: {0}", money));
        }
    }
}

