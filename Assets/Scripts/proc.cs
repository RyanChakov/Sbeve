using System.Collections.Generic;
using UnityEngine;

public class proc : MonoBehaviour
{
    public GameObject chunkPrefab;
   
   
    public World world;
    bool good = false;
    int chunkZ = 20;
    float newX = 0;
    float newZ = 0;
    //260 by 260
    void Update()
    {
        if (!Physics.Raycast( transform.position,  transform.TransformDirection(Vector3.down)))
        {
            good = true;

        }
        if (good)
        { 
            newX =  transform.position.x - ( transform.position.x % 20);
            newZ =  transform.position.z - ( transform.position.z % 20);
            for (int y=0; y<13; y++)
                CreateNewChunkNew((int)newX, y * 20, (int)newZ);
            good = false;
        }

    }
   private void go()
    {


        newX =  transform.position.x - ( transform.position.x % 20);
        newZ =  transform.position.z - ( transform.position.z % 20);
        for (int y=0; y<13; y++)
            CreateNewChunkNew((int)newX, y * 20, (int)newZ);
        good = false;
        /*for (int x = 0; x < 13; x++)
        {
            for (int y = 0; y < 13; y++)
            {
                for (int z = 0; z < 13; z++)
                {
                  
                    CreateNewChunkNew((x * chunkZ)+(int)newX, (y * chunkZ), (z * chunkZ) + (int)newZ);
                }
            }
        }*/
       
    }

    private void CreateNewChunkNew(int x, int y, int z)
    {
        Vector3Int position = new Vector3Int(x, y, z);

        Chunk chunk = Instantiate(chunkPrefab, position, Quaternion.identity).GetComponent<Chunk>();
        chunk.Initialize(world, chunkZ, position);
        world.chunks.Add(position, chunk);
     
    }
}
