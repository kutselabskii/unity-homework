using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2.0f;
    public float MouseSensitivity = 2.0f;

    public Camera Camera;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0);
        var movement = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        controller.Move(movement * Speed * Time.deltaTime);

        var cameraPosition = transform.position - transform.forward * 8 + new Vector3(0f, 4f, 0f);
        Camera.transform.position = cameraPosition;
        Camera.transform.LookAt(transform);
    }
}
