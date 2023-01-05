﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    [SerializeField]
    Light RoomLight = null;

    //état allumé éteint
    public bool lightState = true;

    void Start()
    {
        GameManager.Instance.Light = this;
    }

    void Update()
    {
        
    }

    //allumer et éteindre la lumière
    public void SwitchLight()
    {
        if (lightState)
        {
            RoomLight.intensity = 5;
            lightState = false;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log("turn off");
        }
        else
        {
            RoomLight.intensity = 500;
            lightState = true;
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
            Debug.Log("turn on");
        }
    }
}
