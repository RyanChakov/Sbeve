using System.Collections.Generic;
using UnityEngine;

public class proc : MonoBehaviour
{
    public GameObject chunkPrefab;
   
   
    public World world;
    int chunkZ = 20;
    float newX = 0;
    float newZ = 0;
    //260 by 260
    void Update()
    {
     

        if (!Physics.Raycast( transform.position,  transform.TransformDirection(Vector3.down)))
        {
           if(transform.position.x < 0)
            {
                newX = transform.position.x - ((transform.position.x % 20)+20);
            }
            else
            {
                newX = transform.position.x - (transform.position.x % 20);
            }
            if (transform.position.z < 0)
            {
                newZ = transform.position.z - ((transform.position.z % 20)+20);
            }
            else
            {
                newZ = transform.position.z - (transform.position.z % 20);
            }
            for (int y=0; y<13; y++)
                CreateNewChunkNew((int)newX, y * 20, (int)newZ);
            print(newX + " X");
            print(newZ + " Z");
        }

    }

    private void CreateNewChunkNew(int x, int y, int z)
    {
        Vector3Int position = new Vector3Int(x, y, z);

        Chunk chunk = Instantiate(chunkPrefab, position, Quaternion.identity).GetComponent<Chunk>();
        chunk.Initialize(world, chunkZ, position);
        world.chunks.Add(position, chunk);
     
    }
}
