using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int MaxIntoxication; 
    
    public int MaxAlchol;

    public Image Intoxication;

    public Image Alchol;

    public float IntoxicationIncreasedPerSecond;

    public float AlcholIncreasedPerSecond;

    public float UpdatedIntoxication;

    public float UpdatedAlchol;

    public bool drink = false;

    Animator animator;

    private PlayerInput _intput;

    private void Awake()
    {
       _intput = new PlayerInput();


    }

    private void OnEnable()
    {
        _intput.Enable();
    }

    private void OnDisable()
    {
        _intput.Disable();
    }

    private void Start()
    {

        animator = this.GetComponent<Animator>();
        _intput.GameControls.Drink.performed += ctx => Drink(ctx);

        IntoxicationIncreasedPerSecond = -20f;

        AlcholIncreasedPerSecond = 0f;

        MaxIntoxication = 1000;

        MaxAlchol = 1000;
    }

    private void OnDestroy()
    { 
        _intput.GameControls.Drink.performed -= ctx => Drink(ctx);
    }

    private void Drink(InputAction.CallbackContext ctx)
    {

        if (this.drink)
        {
            drink = false;
            return;
        }
        drink = true;
        animator.SetTrigger("Isdrink");
  
        UpdatedAlchol -= 75f;
        UpdatedIntoxication += 35f;
        Debug.Log("MMMMM");
    }

    private void Update()
    {
        UpdatedIntoxication += IntoxicationIncreasedPerSecond * Time.deltaTime;

        Intoxication.fillAmount = UpdatedIntoxication / MaxIntoxication;  

        UpdatedAlchol += AlcholIncreasedPerSecond * Time.deltaTime;

        Alchol.fillAmount = UpdatedAlchol / MaxAlchol;


        if (UpdatedIntoxication >= MaxIntoxication)
        {
            UpdatedIntoxication = MaxIntoxication;
        }



        if (UpdatedAlchol >= MaxAlchol)
        {
            UpdatedAlchol = MaxAlchol;
        }
    }
}
