using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour
{
    [SerializeField] private bool addTerrain = true;
    [SerializeField] private float force = 2f;
    [SerializeField] private float range = 2f;

    [SerializeField] private float maxReachDistance = 100f;

    [SerializeField] private AnimationCurve forceOverDistance = AnimationCurve.Constant(0, 1, 1);

    [SerializeField] private World world;
    [SerializeField] private Transform playerCamera;
    int runs = 0;
    Chunk[] _initChunks;

    private void Start()
    {
        _initChunks = new Chunk[8];
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(runs<=1)
        { 
        TryEditTerrain1();
        }
        runs++;

    }

    private void TryEditTerrain1()
    {

        RaycastToTerrain1(!addTerrain);
        
    }

    private void RaycastToTerrain1(bool addTerrain)
    {
        Vector3 startP = playerCamera.position;
        Vector3 destP = startP + playerCamera.forward;
        Vector3 direction = destP - startP;

        Ray ray = new Ray(startP, direction);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, maxReachDistance))
        {
            Vector3 hitPoint = hit.point;

            if (addTerrain)
            {
                Collider[] hits = Physics.OverlapBox(hitPoint, new Vector3(1,1,1));
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].CompareTag("Player"))
                    {
                        print(hits[i].tag+" THIS IS THE TAG");
                        return;
                    }
                    
                }
            }
            
            EditTerrain1(hitPoint, addTerrain, force, range);
            // point, false, 2,2
            
        }
    }

    private void EditTerrain1(Vector3 point, bool addTerrain, float force, float range)
    {
        int buildModifier = addTerrain ? 1 : -1;

        int hitX = point.x.Round();
        int hitY = point.y.Round();
        int hitZ = point.z.Round();
        
        int intRange = range.Ceil();
        int yDeepForClearCastleLobby = -3; //Hard Coded Variable to Clear the lobby of the castle, from cube asset
        for (int y = yDeepForClearCastleLobby; y <= intRange; y++)
        {
            int offsetY = hitY + y;

            for (int x = -intRange; x <= intRange; x++)
            {
                int offsetX = hitX + x;

                for (int z = -intRange; z <= intRange; z++)
                {

                int offsetZ = hitZ + z;

                    // if (!world.IsPointInsideWorld(offsetX, offsetY, offsetZ))
                    // continue;
                    float distance = 5f;
                    //float distance = Utils.Distance(offsetX, offsetY, offsetZ, point);
                    //  if (!(distance <= range)) continue;

                float modificationAmount = force / distance * forceOverDistance.Evaluate(1 - distance.Map(0, force, 0, 1)) * buildModifier;

                float oldDensity = world.GetDensity(offsetX, offsetY, offsetZ);
                float newDensity = oldDensity - modificationAmount;

               // newDensity = newDensity.Clamp01();

                world.SetDensity(newDensity, offsetX, offsetY, offsetZ, true, _initChunks);

               
                }
            }
        }

    }
}

