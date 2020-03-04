using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SkeletonFix : MonoBehaviour
{
    
    void Update()
    {
        print(GetComponent<AIPath>().hasPath + " Path");
        print(GetComponent<AIPath>().isActiveAndEnabled+" ACTIVE?ENABLKED");
        print("END");
    }
}
