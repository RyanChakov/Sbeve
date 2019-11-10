using System.Collections.Generic;
using UnityEngine;

public class proc : MonoBehaviour
{
    public GameObject chunkPrefab;
    public GameObject OutCube;
    public World world;
    bool good = false;
    int chunkZ = 20;
    void Update()
    {
        if (!Physics.Raycast(OutCube.transform.position, OutCube.transform.TransformDirection(Vector3.down)))
        {
            good = true;

        }
        if (good)
        { 
            go();
        }

    }
   private void go()
    {
        good = false;
        for (int x = 0; x < chunkZ/2; x++)
        {
            for (int y = 0; y < chunkZ/2; y++)
            {
                for (int z = 0; z < chunkZ/2; z++)
                {
                  
                    CreateNewChunkNew((x * chunkZ)+(int)OutCube.transform.position.x, (y * chunkZ), (z * chunkZ) + (int)OutCube.transform.position.z);
                }
            }
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
