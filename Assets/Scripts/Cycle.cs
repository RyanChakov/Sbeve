using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public Material sky1, sky2, sky3, sky4, sky5, sky6, sky7, sky8;
    public Material[] sky;
    public float cycleT = 16f, timer,slow;
    public int timercount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > cycleT)
        {
            RenderSettings.skybox = sky[timercount];
            timercount++;
            if(timercount==8)
            {
                timercount = 0;
            }
            timer = 0;
        }
        else
        {
           
            sky[timercount].SetFloat("_Blend", Mathf.Lerp(0, 1, Time.deltaTime));
            print(sky[timercount].GetFloat("_Blend"));
            timer += Time.deltaTime;
        }
    }
}
