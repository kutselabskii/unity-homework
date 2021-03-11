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
        //var move = transform.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        //if (move.magnitude > 0) {
        //    Debug.Log($"F: {transform.forward} M: {move}");
        //}
        //transform.Translate(move);
        //transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f));

        transform.Rotate(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0);
        var movement = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        controller.Move(movement * Speed * Time.deltaTime);

        var cameraPosition = transform.position - transform.forward * 4 + new Vector3(0f, 2f, 0f);
        Camera.transform.position = cameraPosition;
        Camera.transform.LookAt(transform);
    }
}
