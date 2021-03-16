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
        transform.Rotate(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0);

        var movement = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
        transform.Translate(movement * Speed * Time.deltaTime);

        var cameraPosition = transform.position - transform.forward * 8 + new Vector3(0f, 4f, 0f);
        Camera.transform.position = cameraPosition;
        Camera.transform.LookAt(transform);
    }
}
