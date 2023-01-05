using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    //état allumé éteint
    bool state = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    //allumer et éteindre la lumière
    public void SwitchState()
    {
        if (state)
        {
            Debug.Log("consoleOff");
            this.GetComponent<SpriteRenderer>().color = Color.black;
            state = false;
        }
        else
        {
            Debug.Log("consoleOn");
            this.GetComponent<SpriteRenderer>().color = Color.white;
            state = true;
        }
    }

}
