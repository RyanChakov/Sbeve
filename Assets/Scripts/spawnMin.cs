using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMin : MonoBehaviour
{
    public GameObject amber,amethyst,aquamarine,coal,copper,emerald,garnet,gold,lapis,obsidian,pearl,ruby,smoky,building1,building2,building3,dungeon;
    // Start is called before the first frame update
    void Start()
    {
      
            int xx = Random.Range(0, 200);
            int yy = Random.Range(0, 100);
            int zz = Random.Range(0, 200);
            Instantiate(dungeon, new Vector3(xx, yy, zz), Quaternion.identity);
        
        for (int q = 0; q < 5; q++)
        {
            int x = Random.Range(0, 200);
           
            int z = Random.Range(0, 200);
            Instantiate(building1, new Vector3(x, 114, z), Quaternion.identity);
        }
        for (int q = 0; q < 10; q++)
        {
            int x = Random.Range(0, 200);
          
            int z = Random.Range(0, 200);
            Instantiate(building2, new Vector3(x, 116, z), Quaternion.identity);
        }
        for (int q = 0; q < 20; q++)
        {
            int x = Random.Range(0, 200);
           
            int z = Random.Range(0, 200);
            Instantiate(building3, new Vector3(x, 114, z), Quaternion.identity);
        }
        for (int q=0; q<50; q++)
        {
            int x= Random.Range(0, 200);
            int y = Random.Range(0, 50);
            int z = Random.Range(0, 200);
            Instantiate(gold, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(amber, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(amethyst, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(aquamarine, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(emerald, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(garnet, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(lapis, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(obsidian, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(pearl, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(ruby, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 100; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 75);
            int z = Random.Range(0, 200);
            Instantiate(smoky, new Vector3(x, y, z), Quaternion.identity);
        }
        for (int q = 0; q < 150; q++)
        {
            int x = Random.Range(0, 200);
            int y = Random.Range(0, 100);
            int z = Random.Range(0, 200);
            Instantiate(coal, new Vector3(x, y, z), Quaternion.identity);
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
