using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 10f * Time.deltaTime, 0f));
    }

    public bool IsNight()
    {
        return transform.eulerAngles.y > 75 && transform.eulerAngles.y < 240;
    }
}
