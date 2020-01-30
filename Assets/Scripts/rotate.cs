using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    bool loading = false;
    float rot=0;
    // Start is called before the first frame update
    void Start()
    {
       
    }
        // Update is called once per frame
     void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(0, 0, rot));
        rot--;
        if (loading==true)
        {
            this.transform.rotation.SetEulerAngles(0, 0, 0);
        }
    }
}
