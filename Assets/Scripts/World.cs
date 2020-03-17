
using System.Collections.Generic;
using System;
using UnityEngine;

public class World : MonoBehaviour
{
    public int chunkSize = 8;
    public GameObject ParentChunk;
    public int worldWidth = 5;
    public int worldHeight = 5;
    public int worldDepth = 5;

    public bool starter = false;

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

    private void Start()
    {
        worldBounds = new Bounds();
        UpdateBounds();

        chunks = new Dictionary<Vector3Int, Chunk>(worldWidth * worldHeight * worldDepth);
        CreateChunks();
    }

    private void CreateChunks()
    {

        int t = DateTime.Now.Second;
        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                for (int z = 0; z < worldDepth; z++)
                {
                    CreateChunk(x * chunkSize, y * chunkSize, z * chunkSize);
                }
            }
        }

        Debug.Log("Time: " + (DateTime.Now.Second - t));
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




        return chunks[new Vector3Int(Math.Abs(Utils.FloorToNearestX(x, chunkSize)), Math.Abs(Utils.FloorToNearestX(y, chunkSize)), Math.Abs(Utils.FloorToNearestX(z, chunkSize)))];

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
        float middleX = worldWidth * chunkSize / 2f;
        float middleY = worldHeight * chunkSize / 2f;
        float middleZ = worldDepth * chunkSize / 2f;

        Vector3 midPos = new Vector3(middleX, middleY, middleZ);

        Vector3Int size = new Vector3Int(
            worldWidth * chunkSize,
            worldHeight * chunkSize,
            worldDepth * chunkSize);

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
        if (starter)
        {
            if (y == 100)
            {
                Vector3Int position = new Vector3Int(x, y, z);

                Chunk chunk = Instantiate(chunkPrefab, position, Quaternion.identity).GetComponent<Chunk>();
                chunk.Initialize(this, chunkSize, position);
                chunk.transform.parent = ParentChunk.transform;
                chunks.Add(position, chunk);
            }

        }
        else
        {

           
            Vector3Int position = new Vector3Int(x, y, z);

            Chunk chunk = Instantiate(chunkPrefab, position, Quaternion.identity).GetComponent<Chunk>();
            chunk.Initialize(this, chunkSize, position);
            chunk.transform.parent = ParentChunk.transform;
            chunks.Add(position, chunk);
            /*if (y == 100)
            {
                chunk.gameObject.layer = 11;
            }
            */
        }
    }

}

