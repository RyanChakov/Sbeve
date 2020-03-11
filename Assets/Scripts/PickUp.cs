using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PickUp : MonoBehaviour
{
    public GameObject cam;
    RaycastHit hit = new RaycastHit();
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI[] oresText = new TextMeshProUGUI[13];
    int[] oresInt = new int[13];
    string[] oresNames = new string[13];
    public float money = 0, totalmoney = 0;
    public float newScale = 0;
    public GameObject slime;

    void Start()
    {
        for (int y = 0; y < 13; y++)
        {
            oresInt[y] = 0;
        }
        oresNames[0] = "Amber";
        oresNames[1] = "Amethyst";
        oresNames[2] = "Aquamarine";
        oresNames[3] = "Coal";
        oresNames[4] = "Copper";
        oresNames[5] = "Emerald";
        oresNames[6] = "Garnet";
        oresNames[7] = "Gold";
        oresNames[8] = "Lapis";
        oresNames[9] = "Obsidian";
        oresNames[10] = "Pearl";
        oresNames[11] = "Ruby";
        oresNames[12] = "Smoky Quartz";


    }

    void Update()
    {

        GameObject test;
        LayerMask mask = LayerMask.GetMask("Ore");

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
            {
                if (hit.collider.gameObject.layer == 9)
                {
                    switch (hit.collider.tag)
                    {
                        case "Amber":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[0]++;
                            break;
                        case "Amethyst":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[1]++;
                            break;
                        case "Aquamarine":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[2]++;
                            break;
                        case "Coal":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[3]++;
                            break;
                        case "Copper":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[4]++;
                            break;
                        case "Emerald":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[5]++;
                            break;
                        case "Garnet":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[6]++;
                            break;
                        case "Gold":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[7]++;
                            break;
                        case "Lapis":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[8]++;
                            break;
                        case "Obsidian":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[9]++;
                            break;
                        case "Pearl":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[10]++;
                            break;
                        case "Ruby":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[11]++;
                            break;
                        case "SmokyQuartz":
                            test = hit.collider.gameObject;
                            Destroy(test);
                            oresInt[12]++;
                            break;
                    }

                }
                else if (hit.collider.name == "Slime")
                {
                    money = (oresInt[0] * 20) + (oresInt[1] * 20) + (oresInt[2] * 20) + (oresInt[3] * 10) + (oresInt[4] * 20) + (oresInt[5] * 30) + (oresInt[6] * 20) + (oresInt[7] * 50) + (oresInt[8] * 20) + (oresInt[9] * 20) + (oresInt[10] * 20) + (oresInt[11] * 40) + (oresInt[12] * 20);
                    totalmoney += money;
                    oresInt[0] = oresInt[1] = oresInt[2] = oresInt[3] = oresInt[4] = oresInt[5] = oresInt[6] = oresInt[7] = oresInt[8] = oresInt[9] = oresInt[10] = oresInt[11] = oresInt[12] = 0;
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

        for (int y = 0; y < 13; y++)
        {
            oresText[y].text = ""+oresInt[y].ToString();
        }
        moneyText.text = ""+money;
    }

    public void Buy(float cost)
    {
        money -= cost;
    }
}

