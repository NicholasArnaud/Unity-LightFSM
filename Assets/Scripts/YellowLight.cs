using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLight : ILightStates{
    private float switchTimer;
    private readonly LightStatePattern light;
    public GameObject yLightBulb;
    public YellowLight(LightStatePattern lightstatepattern){
        light = lightstatepattern;
    }
    public void ToGreenLight(){
        Debug.Log("Can't transition back to Green Light");
    }
    public void ToRedLight(){
        light.currentState = light.redLight;
        switchTimer = 0;
    }
    public void ToYellowLight(){
        Debug.Log("Can't transition to the same state");
    }
    private void LightOn(){
        yLightBulb.GetComponent<Renderer>().material.color = Color.yellow;
        switchTimer += Time.deltaTime;
        if (switchTimer >= light.timer){
            yLightBulb.GetComponent<Renderer>().material.color = Color.white;
            ToRedLight();
        }
    }
    void ILightStates.UpdateState(){
        LightOn();
    }
}