using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public Light sun;
    public Material[] sky;
    public float cycleT = 16f, slow = 0, slows = 0,longDay=.1f;
    public int timercount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        sky[timercount].SetFloat("_Blend", Mathf.Lerp(0, 1, slow));
        slow += longDay * Time.deltaTime;

        if (sky[timercount].GetFloat("_Blend") == 1)
        {
            timercount++;
            slow = 0;
            slows = 0;

            if (timercount == 8)
            {
                timercount = 0;
            }
        }
        RenderSettings.skybox = sky[timercount];
       


        switch (timercount)
        {
            case 0:
                sun.intensity = Mathf.Lerp(.5f, 1, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(.4f, .7f, slows);
                break;
            case 1:
                sun.intensity = Mathf.Lerp(1f, 1.5f, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(.7f, .1f, slows);
                break;
            case 2:
                sun.intensity = Mathf.Lerp(1.5f, 1f, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(1f, .7f, slows);
                break;
            case 3:
                sun.intensity = Mathf.Lerp(1f, .8f, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(.7f, .5f, slows);
                break;
            case 4:
                sun.intensity = Mathf.Lerp(.8f, .5f, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(.5f, .3f, slows);
                break;
            case 5:
                sun.intensity = Mathf.Lerp(.5f, .3f, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(.3f, .2f, slows);
                break;
            case 6:
                sun.intensity = Mathf.Lerp(.3f, .1f, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(.2f, 0f, slows);
                break;
            case 7:
                sun.intensity = Mathf.Lerp(.1f, .5f, slows);
                RenderSettings.ambientIntensity = Mathf.Lerp(0, .4f, slows);
                break;
        }

        slows += longDay/2 * Time.deltaTime;

    }
}
