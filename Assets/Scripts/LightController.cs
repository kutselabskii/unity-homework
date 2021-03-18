using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.Find("Daylight").GetComponent<DaylightController>().IsNight()) {
            GetComponentInChildren<Light>().enabled = true;
        } else {
            GetComponentInChildren<Light>().enabled = false;
        }
    }
}
