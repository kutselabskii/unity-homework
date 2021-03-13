using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2.0f;
    public float MouseSensitivity = 2.0f;

    public Camera Camera;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f));

        var cameraPosition = transform.position - transform.forward * 2 + new Vector3(0f, 2f, 0f);
        Camera.transform.position = cameraPosition;
        Camera.transform.LookAt(transform);
    }
}
