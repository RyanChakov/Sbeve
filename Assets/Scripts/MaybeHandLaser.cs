using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;
public class MaybeHandLaser : MonoBehaviour
{
    public TerrainEditor Terr;
    public GameObject Cam;
    public Animator RobotAnim;
    public float angles;
    [Header("Particle Start")]
    public GameObject eye1, eye2;
    [Header("Laser Start")]
    public GameObject finger1, finger2;
    public GameObject reticle;
    public VolumetricLineBehavior VBL, VBL2;
    private Vector3 hitpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angles = Cam.transform.localEulerAngles.x;
        if (angles > 95)
        {
            angles -= 360;
        }
        RobotAnim.SetFloat("CameraPosX", angles);
        RobotAnim.SetInteger("C", (int)angles);

        if (RobotAnim.GetBool("Mining") && Input.GetButton("Fire1"))
        {
            HandDestroyGround();
        }
        else
        {
            eye1.SetActive(false);
            eye2.SetActive(false);
            VBL.StartPos = Vector3.zero;
            VBL.EndPos = Vector3.zero;
            VBL2.StartPos = Vector3.zero;
            VBL2.EndPos = Vector3.zero;
        }

    }


    void HandDestroyGround()
    {
        hitpoint = reticle.transform.position;
        Vector3 destP = Cam.transform.position + Cam.transform.forward;
        Vector3 direction = destP - Cam.transform.position;
        Ray ray = new Ray(Cam.transform.position, direction);
        Debug.DrawRay(Cam.transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {   
            hitpoint = hit.point;
        }

        eye1.SetActive(true);
        eye1.transform.LookAt(new Vector3(hitpoint.x, hitpoint.y, hitpoint.z));
        VBL.StartPos = finger1.transform.position;
        VBL.EndPos = new Vector3(hitpoint.x, hitpoint.y, hitpoint.z);

        eye2.SetActive(true);
        eye2.transform.LookAt(new Vector3(hitpoint.x, hitpoint.y, hitpoint.z));
        VBL2.StartPos = finger2.transform.position;
        VBL2.EndPos = new Vector3(hitpoint.x, hitpoint.y, hitpoint.z);
    }
}
