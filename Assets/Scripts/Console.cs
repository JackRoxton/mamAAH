using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    //état allumé éteint
    public bool state = false;

    void Start()
    {
        GameManager.Instance.Console = this;
    }

    void Update()
    {
        
    }


    //allumer et éteindre la lumière
    public void SwitchState()
    {
        if (state)
        {
            this.GetComponent<SpriteRenderer>().color = Color.black;
            state = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            state = true;
        }
    }

}
