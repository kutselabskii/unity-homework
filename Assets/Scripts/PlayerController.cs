using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var controller = GetComponent<CharacterController>();

        controller.Move(moveVector * Time.deltaTime);
    }
}
