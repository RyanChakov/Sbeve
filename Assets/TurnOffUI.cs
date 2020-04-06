using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffUI : MonoBehaviour
{
    public GameObject UI;

   void Start()
    {
        UI.SetActive(false);
    }
}
