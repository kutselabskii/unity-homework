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
        transform.Rotate(0f, Input.GetAxis("Mouse X") * MouseSensitivity, 0f);

        transform.Translate(transform.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        transform.Translate(transform.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);

        var cameraPosition = transform.position - transform.forward * 2 + new Vector3(0f, 2f, 0f);
        Camera.transform.position = cameraPosition;
        Camera.transform.LookAt(transform);
    }
}
