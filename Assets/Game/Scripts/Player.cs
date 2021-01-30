using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    private void Start()
    {
        this.IntoxicationIncreasedPerSecond = 5f;

        this.AlcholIncreasedPerSecond = -1f;

        this.MaxIntoxication = 1000;

        this.MaxAlchol = 1000;
    }

    private void Update()
    {
        this.UpdatedIntoxication += this.IntoxicationIncreasedPerSecond * Time.deltaTime;

        this.Intoxication.fillAmount = this.UpdatedIntoxication / this.MaxIntoxication;  

        this.UpdatedAlchol += this.AlcholIncreasedPerSecond * Time.deltaTime;

        this.Alchol.fillAmount = this.UpdatedAlchol / this.MaxAlchol;


        if (this.UpdatedIntoxication >= this.MaxIntoxication)
        {
            this.UpdatedIntoxication = this.MaxIntoxication;
        }



        if (this.UpdatedAlchol >= this.MaxAlchol)
        {
            this.UpdatedAlchol = this.MaxAlchol;
        }
    }
}
