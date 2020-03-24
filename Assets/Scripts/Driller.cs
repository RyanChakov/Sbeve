using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driller : MonoBehaviour
{
    public GameObject head;
    public GameObject Bit;
    public Transform main;
    public Transform BIG;
    float bitter = 0;
    bool start = false;
    public float scale = 5;
    float testing = 1, timT = 0.0f, testing2 = 1, timT2 = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }
    //1 0
    //2 1.04
    //3 2.1
    //4 3.14
    //5 4.12
    //y=
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
           // BIG.localRotation = head.transform.localRotation;
            if (start)
            {
                print(transform.position.y + "This is the y");
                print(((1.034f * scale) - 1.022f) + "This is the Formula outcome");
                resetSome();
                bitter = transform.localPosition.y + ((1.034f * scale) - 1.022f);
                start = false;
            }
            testing = Mathf.Lerp(0, bitter, timT);
            timT += 0.5f * Time.deltaTime;
            testing2 = Mathf.Lerp(1, scale, timT2);
            timT2 += .5f * Time.deltaTime;
            BIG.transform.Rotate(new Vector3(0, 20, 0));
            Bit.transform.localPosition = new Vector3(0, testing, 0);
            this.transform.localScale = new Vector3(1, testing2, 1);


        }
        else
        {
           /*
            if(BIG.transform.rotation.w != 0)
            {
                Quaternion target = Quaternion.Euler(0, 0, 90);
                BIG.transform.rotation = target;
            }
            */
            if (!start)
                resetSome();
            if (transform.localPosition.y != 0)
            {

              
                testing = Mathf.Lerp(transform.localPosition.y, 0, timT);
                timT += 0.5f * Time.deltaTime;
                testing2 = Mathf.Lerp(transform.localScale.y, 1, timT2);
                timT2 += .5f * Time.deltaTime;
                Bit.transform.localPosition = new Vector3(0, testing, 0);
                this.transform.localScale = new Vector3(1, testing2, 1);

            }
            start = true;
            // transform.localScale = new Vector3(1, 1, 1);
            // transform.localPosition =new Vector3(0,0,0);
        }
    }
    void resetSome()
    {

        bitter = 0;
        timT = 0;
        timT2 = 0;
        testing = 0;
        testing2 = 0;

    }

}
