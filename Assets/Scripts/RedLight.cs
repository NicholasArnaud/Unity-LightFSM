using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : ILightStates{
    private float switchTimer;
    private readonly LightStatePattern light;
    public GameObject rLightBulb;
    public RedLight(LightStatePattern lightstatepattern){
        light = lightstatepattern;
    }
    public void ToGreenLight(){
        light.currentState = light.greenLight;
        switchTimer = 0;
    }
    public void ToRedLight(){
        Debug.Log("Can't transition to the same state");
    }
    public void ToYellowLight(){
        Debug.Log("Can't transition back to Yellow Light");
    }
    private void LightOn(){
        rLightBulb.GetComponent<Renderer>().material.color = Color.red;
        switchTimer += Time.deltaTime;
        if (switchTimer >= light.timer){
            rLightBulb.GetComponent<Renderer>().material.color = Color.white;
            ToGreenLight();
        }
    }
    void ILightStates.UpdateState(){
        LightOn();
    }
}