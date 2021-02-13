using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Behaviours;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private bool _drink = false;

    Animator _animator;

    private PlayerInput _intput;

    private PlayerAlcholBehaviour _alcholBehaviour;

    private void Awake()
    {
       _intput = new PlayerInput();
       _animator = GetComponent<Animator>();
       _alcholBehaviour = GetComponent<PlayerAlcholBehaviour>();
       _intput.Enable();
    }

    private void OnEnable()
    {
        _intput.GameControls.Drink.performed +=Drink;
    }

    private void OnDisable()
    {
        _intput.GameControls.Drink.performed -=Drink;
    }
    
    private void OnDestroy()
    {
        _intput.Disable();
    }

    private void Drink(InputAction.CallbackContext ctx)
    {

        if (this._drink)
        {
            _drink = false;
            return;
        }
        _drink = true;
        _animator.SetTrigger("Isdrink");

        _alcholBehaviour.Drink();

    }

    
}
