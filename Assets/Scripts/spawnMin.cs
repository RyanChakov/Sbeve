using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMin : MonoBehaviour
{
    public GameObject amber,amethyst,aquamarine,coal,copper,emerald,garnet,gold,lapis,obsidian,pearl,ruby,smoky,building1,building2,building3,dungeon,ParentSurf,ParentOre;
    GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
      
            int xx = Random.Range(38, 260);
            int yy = Random.Range(0, 100);
            int zz = Random.Range(30, 260);
            temp = Instantiate(dungeon, new Vector3(xx, yy, zz), Quaternion.identity);
        temp.transform.parent = ParentSurf.transform;
        
        for (int q = 0; q < 5; q++)
        {
            int x = Random.Range(0, 260);
            int z = Random.Range(0, 260);
           temp = Instantiate(building1, new Vector3(x, 114, z), Quaternion.identity);
            temp.transform.parent = ParentSurf.transform;
        }
        for (int q = 0; q < 10; q++)
        {
            int x = Random.Range(0, 260);
          
            int z = Random.Range(0, 260);
           temp =  Instantiate(building2, new Vector3(x, 116, z), Quaternion.identity);
            temp.transform.parent = ParentSurf.transform;
        }
        for (int q = 0; q < 20; q++)
        {
            int x = Random.Range(0, 260);
           
            int z = Random.Range(0, 260);
            temp = Instantiate(building3, new Vector3(x, 114, z), Quaternion.identity);
            temp.transform.parent = ParentSurf.transform;
        }
        for (int q=0; q<50; q++)
        {
            int x= Random.Range(0, 260);
            int y = Random.Range(0, 50);
            int z = Random.Range(0, 260);
            temp = Instantiate(gold, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
           temp =  Instantiate(amber, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
           temp =  Instantiate(amethyst, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
           temp = Instantiate(aquamarine, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
           temp =  Instantiate(emerald, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
          temp =  Instantiate(garnet, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
            temp  = Instantiate(lapis, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
            temp = Instantiate(obsidian, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
            temp  = Instantiate(pearl, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
           temp =  Instantiate(ruby, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 260);
           temp =  Instantiate(smoky, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
        for (int q = 0; q < 150; q++)
        {
            int x = Random.Range(0, 260);
            int y = Random.Range(0, 100);
            int z = Random.Range(0, 260);
            temp = Instantiate(coal, new Vector3(x, y, z), Quaternion.identity);
            temp.transform.parent = ParentOre.transform;
        }
       

    }
}
