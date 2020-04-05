using UnityEngine;
using VolumetricLines;
public class TerrainEditor : MonoBehaviour
{
    [SerializeField] private bool addTerrain = true;
    [SerializeField] private float force = 2f;
    [SerializeField] private float range = 2f;
    public Show show;
   
    [SerializeField] private float maxReachDistance = 100f;
    public float standardForce = .25f;
    public int standardDepth = 200;
    [SerializeField] private AnimationCurve forceOverDistance = AnimationCurve.Constant(0, 1, 1);

    [SerializeField] private World world;
    [SerializeField] private Transform playerCamera;
 
    Chunk[] _initChunks;

    public LineRenderer line;
    private void Start()
    {
        _initChunks = new Chunk[8];
        Cursor.lockState = CursorLockMode.Locked;



    }

    private void Update()
    {
       
        TryEditTerrain();
    }

    private void TryEditTerrain()
    {
        if (force <= 0 || range <= 0)
        {
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            RaycastToTerrain(!addTerrain);
        }
    }

    private void RaycastToTerrain(bool addTerrain)
    {
        Vector3 startP = playerCamera.position;
        Vector3 destP = startP + playerCamera.forward;
        Vector3 direction = destP - startP;

        Ray ray = new Ray(startP, direction);
       
        if (Physics.Raycast(ray, out RaycastHit hit, maxReachDistance))
        {
            
            Vector3 hitPoint = hit.point;
           
            // VBL.EndPos = new Vector3(hitPoint.x + (Random.Range(-4, 4)), hitPoint.y + (Random.Range(-4, 4)), hitPoint.z);
           
            if (addTerrain)
            {
                Collider[] hits = Physics.OverlapSphere(hitPoint, range / 2f * 0.8f);

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].CompareTag("Player"))
                    {
                        return;
                    }
                }
            }
            if (show.pic3)
            {
                standardForce = 1f;
                standardDepth = -20;
                range = 8f;
            }
            else if (show.pic2)
            {
                standardForce = .75f;
                standardDepth = 40;
                range = 6f;
            }
            else if (show.pic1)
            {
                standardForce = .5f;
                standardDepth = 140;
                range = 5.5f;
            }
            else
            {
                standardDepth = 240;
                standardForce = .25f;
            }

            if (hitPoint.y <= standardDepth)
            {
                force = 0.0000001f;
            }
            else
            {
                force = standardForce;
            }
            EditTerrain(hitPoint, addTerrain, force, range);
            // point, false, 2,2
        }
    }

    private void EditTerrain(Vector3 point, bool addTerrain, float force, float range)
    {
        int buildModifier = addTerrain ? 1 : -1;

        int hitX = point.x.Round();
        int hitY = point.y.Round();
        int hitZ = point.z.Round();

        int intRange = range.Ceil();

        for (int x = -intRange; x <= intRange; x++)
        {
            for (int y = -intRange; y <= intRange; y++)
            {
                for (int z = -intRange; z <= intRange; z++)
                {
                    int offsetX = hitX - x;
                    int offsetY = hitY - y;
                    int offsetZ = hitZ - z;

                    /* if (!world.IsPointInsideWorld(offsetX, offsetY, offsetZ))
                         continue;
                         */
                    float distance = Utils.Distance(offsetX, offsetY, offsetZ, point);
                    if (!(distance <= range)) continue;

                    float modificationAmount = force / distance * forceOverDistance.Evaluate(1 - distance.Map(0, force, 0, 1)) * buildModifier;

                    float oldDensity = world.GetDensity(offsetX, offsetY, offsetZ);
                    float newDensity = oldDensity - modificationAmount;

                    newDensity = newDensity.Clamp01();

                    world.SetDensity(newDensity, offsetX, offsetY, offsetZ, true, _initChunks);

                }
            }
        }
    }
}

