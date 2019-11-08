using System.Collections.Generic;
using UnityEngine;

public class proc : MonoBehaviour
{
    public World wr;
    public int chunkSize = 8;

    public int worldWidth = 5;
    public int worldHeight = 5;
    public int worldDepth = 5;

    public float isolevel;

    public int seed;

    public GameObject chunkPrefab;

    public Dictionary<Vector3Int, Chunk> chunks;

    private Bounds worldBounds;

    public DensityGenerator densityGenerator;

    private void Awake()
    {
        densityGenerator = new DensityGenerator(seed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(worldBounds.center, worldBounds.size);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        { 
        worldBounds = new Bounds();
        UpdateBounds();

        chunks = new Dictionary<Vector3Int, Chunk>(worldWidth * worldHeight * worldDepth); ;
        CreateChunks();
        }
    }

    private void CreateChunks()
    {
        for (int x = worldWidth; x < worldWidth+5; x++)
        {
            for (int y = worldHeight; y < worldHeight+5; y++)
            {
                for (int z = worldDepth; z < worldDepth+5; z++)
                {
                    CreateChunk(x * chunkSize, y * chunkSize, z * chunkSize);
                }
            }
        }
    }

    private Chunk GetChunk(Vector3Int pos)
    {
        return GetChunk(pos.x, pos.y, pos.z);
    }

    public Chunk GetChunk(int x, int y, int z)
    {
        int newX = Utils.FloorToNearestX(x, chunkSize);
        int newY = Utils.FloorToNearestX(y, chunkSize);
        int newZ = Utils.FloorToNearestX(z, chunkSize);

        return chunks[new Vector3Int(newX, newY, newZ)];
    }

    public float GetDensity(int x, int y, int z)
    {
        Point p = GetPoint(x, y, z);

        return p.density;
    }

    public float GetDensity(Vector3Int pos)
    {
        return GetDensity(pos.x, pos.y, pos.z);
    }

    public Point GetPoint(int x, int y, int z)
    {
        Chunk chunk = GetChunk(x, y, z);

        Point p = chunk.GetPoint(x.Mod(chunkSize),
                                 y.Mod(chunkSize),
                                 z.Mod(chunkSize));

        return p;
    }

    public void SetDensity(float density, int worldPosX, int worldPosY, int worldPosZ, bool setReadyForUpdate, Chunk[] initChunks)
    {
        Vector3Int dp = new Vector3Int(worldPosX, worldPosY, worldPosZ);

        Vector3Int lastChunkPos = dp.FloorToNearestX(chunkSize);

        for (int i = 0; i < 8; i++)
        {
            Vector3Int chunkPos = (dp - MarchingCubes.CubePoints[i]).FloorToNearestX(chunkSize);

            if (i != 0 && chunkPos == lastChunkPos)
            {
                continue;
            }

            Chunk chunk = GetChunk(chunkPos);

            lastChunkPos = chunk.position;

            Vector3Int localPos = (dp - chunk.position).Mod(chunkSize + 1);

            chunk.SetDensity(density, localPos);
            if (setReadyForUpdate)
                chunk.readyForUpdate = true;
        }
    }

    public void SetDensity(float density, Vector3Int pos, bool setReadyForUpdate, Chunk[] initChunks)
    {
        SetDensity(density, pos.x, pos.y, pos.z, setReadyForUpdate, initChunks);
    }

    private void UpdateBounds()
    {
        float middleX = worldWidth+5 * chunkSize / 2f;
        float middleY = worldHeight+5 * chunkSize / 2f;
        float middleZ = worldDepth+5 * chunkSize / 2f;

        Vector3 midPos = new Vector3(middleX, middleY, middleZ);

        Vector3Int size = new Vector3Int(
            worldWidth+5 * chunkSize,
            worldHeight+5 * chunkSize,
            worldDepth+5 * chunkSize);

        worldBounds.center = midPos;
        worldBounds.size = size;
    }

    public bool IsPointInsideWorld(int x, int y, int z)
    {
        return IsPointInsideWorld(new Vector3Int(x, y, z));
    }

    public bool IsPointInsideWorld(Vector3Int point)
    {
        return worldBounds.Contains(point);
    }

    public void CreateChunk(int x, int y, int z)
    {
        Vector3Int position = new Vector3Int(x, y, z);

        Chunk chunk = Instantiate(chunkPrefab, position, Quaternion.identity).GetComponent<Chunk>();
        chunk.Initialize(wr, chunkSize, position);
        chunks.Add(position, chunk);
    }
}
