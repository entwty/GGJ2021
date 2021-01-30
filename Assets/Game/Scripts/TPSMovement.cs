using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSMovement : MonoBehaviour
{
    public CharacterController characterController;

    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + this.cam.eulerAngles.y;

            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngel,ref this.turnSmoothVelocity,turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angel, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;

            this.characterController.Move(moveDir.normalized * this.speed * Time.deltaTime);


        }
    }
}
