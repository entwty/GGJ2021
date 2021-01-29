﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts
{
    public class Test : MonoBehaviour
    {
        private PlayerInput _input;

        private void Awake()
        {
            if (_input == null)
            {
                _input = new PlayerInput();
            }

            _input.GameControls.Interaction.performed += InteractionOnperformed;
            _input.GameControls.Movement.performed+= MovementOnperformed;
            _input.Enable();
        }

        private void MovementOnperformed(InputAction.CallbackContext obj)
        {
           Debug.Log(obj.ReadValue<Vector2>());
        }

        private void OnDestroy()
        {
            _input.GameControls.Interaction.performed -= InteractionOnperformed;
            _input.GameControls.Movement.performed-= MovementOnperformed;
        }

        private void InteractionOnperformed(InputAction.CallbackContext obj)
        {
            Debug.Log("Interaction");
        }
    }
}