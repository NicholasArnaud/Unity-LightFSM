using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLight : ILightStates
{
    private float switchTimer;
    private readonly LightStatePattern light;
    public GameObject gLightBulb;

    public GreenLight(LightStatePattern lightstatepattern)
    {
        light = lightstatepattern;
    }

    public void ToGreenLight()
    {
        Debug.Log("Can't transition to the same state");
    }

    public void ToRedLight()
    {
        Debug.Log("Can't transition directly to Red Light");
    }

    public void ToYellowLight()
    {
        light.currentState = light.yellowLight;
        switchTimer = 0;
    }

    private void LightOn()
    {
        gLightBulb.GetComponent<Renderer>().material.color = Color.green;
        switchTimer += Time.deltaTime;
        if (switchTimer >= light.timer)
        {
            gLightBulb.GetComponent<Renderer>().material.color = Color.white;
            ToYellowLight();
            
        }

    }
    void ILightStates.UpdateState()
    {
        LightOn();
    }
}
