using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Volume : MonoBehaviour
{
    public AudioMixer ambient, background, game, menu;

    public void SetLevelAmb(float sliderValue)
    {
        ambient.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelBack(float sliderValue)
    {
        background.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelGame(float sliderValue)
    {
        game.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelMenu(float sliderValue)
    {
        menu.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelMaster(float sliderValue)
    {
        ambient.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        background.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        game.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        menu.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
