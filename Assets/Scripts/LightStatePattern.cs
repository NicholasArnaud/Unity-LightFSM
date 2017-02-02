using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStatePattern : MonoBehaviour {
    public float timer = 5;


    [HideInInspector]
    public ILightStates currentState;
    public GreenLight greenLight;
    public YellowLight yellowLight;
    public RedLight redLight;
    public float duration = 1.0F;
    public Renderer rend;

    private void Awake()
    {
        greenLight = new GreenLight(this);
        yellowLight = new YellowLight(this);
        redLight = new RedLight(this);
        foreach(Transform go in GetComponentsInChildren<Transform>())
        {
            if (go.name == "GreenLight")
                greenLight.gLightBulb = go.gameObject;
            if(go.name == "YellowLight")
                yellowLight.yLightBulb = go.gameObject;
            if (go.name == "RedLight")
                redLight.rLightBulb = go.gameObject;
        }
    }

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        currentState = greenLight;
	}
	
	// Update is called once per frame
	void Update () {
        rend.material.color = Color.black;
        
        currentState.UpdateState();
	}
}