using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts
{
    public class Test : MonoBehaviour
    {
        private PlayerInput _input;

        private Vector2 movementInput;

        [SerializeField]
        private float moveSpeed = 10f;

        private Vector3 inputDirection;

        private Vector3 moveVector;

        private Quaternion currentRotation;



        private void Awake()
        {
            if (_input == null)
            {
                _input = new PlayerInput();
            }

            this._input.GameControls.Movement.performed += context => this.movementInput = context.ReadValue<Vector2>();


        }

        private void FixedUpdate()
        {
       
            float h = this.movementInput.x;

            float v = this.movementInput.y;

            Vector3 targetInput = new Vector3(h, 0, v);

            this.inputDirection = Vector3.Lerp(this.inputDirection, targetInput, Time.deltaTime * 10f);

            Vector3 camForward = Camera.main.transform.forward;

            Vector3 camRight = Camera.main.transform.right;

            camForward.y = 0f;

            camRight.y = 0f;

            Vector3 desiredDirection = camForward * this.inputDirection.z + camRight * this.inputDirection.x;

            Move(desiredDirection);
            Turn(desiredDirection);
        }

        private void Move(Vector3 desiredDirection)
        {
            this.moveVector.Set(desiredDirection.x,0f,desiredDirection.z);
            this.moveVector = this.moveVector * this.moveSpeed * Time.deltaTime;
            transform.position += this.moveVector;
        }

        private void Turn(Vector3 desiredDirection)
        {
            if ((desiredDirection.x > 0.1 || desiredDirection.x < -0.1 || (desiredDirection.z > 0.1 || desiredDirection.z < -0.1)))
            {
                this.currentRotation = Quaternion.LookRotation(desiredDirection);
                transform.rotation = this.currentRotation;
            }
            else
            {
                transform.rotation = this.currentRotation;
            }
        }

        private void OnEnable()
        {
            this._input.GameControls.Enable();
        }

        private void OnDisable()
        {
            this._input.GameControls.Enable();

        }
    }
}